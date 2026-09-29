/*Dit is een Array. O-o */
const projecten = [
  {
    project: "Vang de volger",
    beschrijving:
      "Vang de volger is een klassieke opdracht waar je als een vis de visser moest opsluiten door het gebruik van dozen.",
    taal: "Java",
  },

  {
    project: "Fresh Fridge",
    beschrijving:
      "Hier hebben we een applicatie gemaakt die alles opslaat dat je scant met een barcode scanner. Zo kon je makkelijk terugkijken wat er nog in de koelkast is.",
    taal: "Java, HTML, CSS",
  },

  {
    project: "Hotel simulator",
    beschrijving:
      "Een simulatie van een hotel die wij moesten realizeren door de events die wij kregen via een library.",
    taal: "Java",
  },

  {
    project: "Portfolio",
    beschrijving:
      "Mijn portfolio! Dat is deze website waar je momenteel naar kijkt!",
    taal: "HTML, CSS, JavaScrypt",
  },
];

const projectContainer = document.querySelector(".project-container");

function toonProjecten(projecten) {
  projecten.forEach((project, index) => {
    const projectDiv = document.createElement("div");

    /*Zorgt ervoor dat de array fancy is met links en rechts. :3 */
    if (index % 2 === 0) {
      projectDiv.classList.add("Links");
    } else {
      projectDiv.classList.add("Rechts");
    }
    const titel = document.createElement("h1");
    const beschrijving = document.createElement("p");
    const taal = document.createElement("h3");

    titel.textContent = project.project;
    beschrijving.textContent = project.beschrijving;
    taal.textContent = project.taal;

    projectDiv.appendChild(titel);
    projectDiv.appendChild(beschrijving);
    projectDiv.appendChild(taal);

    projectContainer.appendChild(projectDiv);
  });
}

/*Filterrrr!!!*/
const filter = document.querySelector("#filter");

filter.addEventListener("change", () => {

  const gekozenTaal = filter.value;

  if (gekozenTaal === "alle") {

    /*Eerst array leeg maken voordat weer array opschrijven.*/
    projectContainer.innerHTML=""; 
    toonProjecten(projecten);

  } else {

    console.log(filter.value);

    const gefilterdeProjecten = projecten.filter((project) => {

      return project.taal.includes(gekozenTaal);
    });
  

    projectContainer.innerHTML = "";

    toonProjecten(gefilterdeProjecten);
  }
});

/* Zorgt ervoor dat de gebruiker niet in een leeg bladzijde komt. */
toonProjecten(projecten);
