async function buttonClick () {
  let value = document.getElementById('quantity').innerText;
  fetch(`/test_rasp/${value}`).then(res => res.json()).then(_ => {
    window.location.href = '/review';
  });
}
