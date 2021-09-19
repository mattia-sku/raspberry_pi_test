import os

from flask import Flask, render_template, Response
import numpy as np
import cv2 as cv
from gpiozero import PWMLED
from time import sleep
import asyncio


def create_app(test_config=None):
    # create and configure the app
    app = Flask(__name__, instance_relative_config=True)
    app.config.from_mapping(
        SECRET_KEY='dev',
        DATABASE=os.path.join(app.instance_path, 'flaskr.sqlite'),
    )

    if test_config is None:
        # load the instance config, if it exists, when not testing
        app.config.from_pyfile('config.py', silent=True)
    else:
        # load the test config if passed in
        app.config.from_mapping(test_config)

    # ensure the instance folder exists
    try:
        os.makedirs(app.instance_path)
    except OSError:
        pass

    # index page
    @app.route('/index/')
    @app.route('/')
    def hello():
        return render_template('index.html')

    def gen():
        cv.destroyAllWindows()
        cap = cv.VideoCapture(0)
        fourcc = cv.VideoWriter_fourcc(*'XVID')

        try:
            while True:
                ret, frame = cap.read()
                if ret:
                    ret, buffer = cv.imencode('.jpg', frame)  
                    if ret:
                        yield (b'--frame\r\n'
                            b'Content-Type: image/jpeg\r\n\r\n' + buffer.tobytes() + b'\r\n\r\n')
        finally:
            cap.release()
            cv.destroyAllWindows()

    def gen_capture():
        cv.destroyAllWindows()
        cap = cv.VideoCapture(0)
        fourcc = cv.VideoWriter_fourcc(*'XVID')
        out = cv.VideoWriter('./flaskr/static/video_output.avi', fourcc, 60.0, (640,  480))
        led = LED(4)
        led.on()

        try:
            for i in range(0,600):
                ret, frame = cap.read()
                if ret:
                    ret, buffer = cv.imencode('.jpg', frame)  
                    out.write(frame)
                    if ret:
                        yield (b'--frame\r\n'
                            b'Content-Type: image/jpeg\r\n\r\n' + buffer.tobytes() + b'\r\n\r\n')
            led.off()
        finally:
            out.release()
            cap.release()
            cv.destroyAllWindows()

    @app.route('/video_feed')
    def video_feed():
        return Response(gen(), mimetype='multipart/x-mixed-replace; boundary=frame')
    @app.route('/video_feed_capture')
    def video_feed_capture():
        return Response(gen_capture(), mimetype='multipart/x-mixed-replace; boundary=frame')

    @app.route('/review')
    def review():
        return render_template('review.html')

    def gen_review():
        cv.destroyAllWindows()
        try:
            while True:
                cap = cv.VideoCapture('flaskr/static/video_output.avi')
                while True:
                    ret, frame = cap.read()
                    if not ret:
                        break
                    ret, buffer = cv.imencode('.jpg', frame)  
                    if not ret:
                        break
                    yield (b'--frame\r\n'
                        b'Content-Type: image/jpeg\r\n\r\n' + buffer.tobytes() + b'\r\n\r\n')

        finally:
            cap.release()
            cv.destroyAllWindows()

    @app.route('/review_video')
    def review_video():
        return Response(gen_review(), mimetype='multipart/x-mixed-replace; boundary=frame')

    
    @app.route('/test_rasp/<value>')
    def test_rasp(value="0.1"):       
        value = float(value)
        if value > 1 or value < 0:
            return 'wrong input'

        cv.destroyAllWindows() 
        cap = cv.VideoCapture(0)
        fourcc = cv.VideoWriter_fourcc(*'XVID')
        out = cv.VideoWriter('./flaskr/static/video_output.avi', fourcc, 60.0, (640,  480))
        led = PWMLED(4)
        led.value = 0.5
        for i in range(0,600):
            ret, frame = cap.read()
            if ret:
                ret, buffer = cv.imencode('.jpg', frame)  
                out.write(frame)
        led.value = 0
        out.release()
        cap.release()
        cv.destroyAllWindows()
        return 'hello'

    return app