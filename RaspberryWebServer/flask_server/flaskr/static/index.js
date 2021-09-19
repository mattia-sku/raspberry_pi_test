async function buttonClick () {
  let value = document.getElementById('quantity').innerText;
  await fetch(`/test_rasp/${value}`);
  window.location.href = '/review';
}
