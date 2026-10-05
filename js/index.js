const foxImage = document.getElementById("fox-image");
const loading = document.getElementById("loading");
const loadingFailed = document.getElementById("loadingFailed");

loading.textContent = "Bezig met laden van vos...";

async function fetchFoxImage() {
  try {
    const response = await fetch("https://randomfox.ca/floof/");
    const data = await response.json();
    foxImage.src = data.image;
    loading.remove(); // Verwijder de laadtekst zodra de afbeelding is geladen
  } catch (error) {
    loadingFailed.textContent = "Er is een fout opgetreden bij het laden van de vos.";
  }
}

fetchFoxImage();
