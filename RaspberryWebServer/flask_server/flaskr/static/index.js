function buttonClick () {
  document.querySelector('img').src = '/video_feed_capture';

  window.setTimeout(() => {
    window.location.href = '/review';
  }, 10000);
}
