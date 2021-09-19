function buttonClick () {
  let value = document.getElementById('quantity').innerText;
  fetch(`/test_rasp/${value}`).then(() => {
    window.location.href = '/review';
  });
}
