async function buttonClick () {
  document.querySelector('button').disabled = true;
  fetch(`/test_rasp`).then(res => res.json()).then(_ => {
    window.location.href = '/review';
  });
}
