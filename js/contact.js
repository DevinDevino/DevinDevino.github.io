const contactForm = document.getElementById("contact-form");
const nameInput = document.getElementById("name");
const emailInput = document.getElementById("email");
const messageInput = document.getElementById("message");
const nameError = document.getElementById("name-error");
const emailError = document.getElementById("email-error");
const messageError = document.getElementById("message-error");

contactForm.addEventListener("submit", function (event) {
  event.preventDefault(); // Voorkom dat het formulier standaard wordt verzonden

  if (!nameInput.value) {
    nameError.textContent = "Vul alstublieft naam in.";
    return;
  } else {
    nameError.textContent = "";
  }
  if (!emailInput.value || !emailInput.checkValidity()) {
    emailError.textContent = "Vul alstublieft een geldig email in.";
    console.log("Email is niet geldig:", emailInput.value);
    return;
  } else {
    emailError.textContent = "";
  }
  if (!messageInput.value) {
    messageError.textContent = "Vul alstublieft bericht in.";
    return;
  } else {
    messageError.textContent = "";
  }

  console.log("Naam:", nameInput.value);
  console.log("Email:", emailInput.value);
  console.log("Bericht:", messageInput.value);
  console.log("Formulier verzonden!");
});

