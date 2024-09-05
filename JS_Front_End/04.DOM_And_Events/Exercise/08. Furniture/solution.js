function solve() {
   const buttons = document.querySelectorAll("#exercise button");
   const generateButton = buttons[0];
   const buyButton = buttons[1];

   generateButton.addEventListener("click", (e) => {
      const table = document.querySelector("table.table tbody");
      const json = document.querySelector("#exercise textarea:first-of-type").value;
      const furnitureObjects = JSON.parse(json);

      furnitureObjects.forEach((object) => {
         const row = document.createElement("tr");
   
         const imageTd = document.createElement("td");
         const image = document.createElement("img");
         image.src = object.img;
         imageTd.appendChild(image);

         const nameTd = document.createElement("td");
         const nameParagraph = document.createElement("p");
         nameParagraph.textContent = object.name;
         nameTd.appendChild(nameParagraph);

         const priceTd = document.createElement("td");
         const priceParagraph = document.createElement("p");
         priceParagraph.textContent = object.price;
         priceTd.appendChild(priceParagraph);

         const decFactorTd = document.createElement("td");
         const decFactorParagraph = document.createElement("p");
         decFactorParagraph.textContent = object.decFactor;
         decFactorTd.appendChild(decFactorParagraph);

         const checkboxTd = document.createElement("td");
         const checkbox = document.createElement("input");
         checkbox.type = "checkbox";
         checkboxTd.appendChild(checkbox);

         row.appendChild(imageTd);
         row.appendChild(nameTd);
         row.appendChild(priceTd);
         row.appendChild(decFactorTd);
         row.appendChild(checkboxTd);

         table.appendChild(row);
      });
   });

   buyButton.addEventListener("click", (e) => {
      const selectedFurniture = Array.from(document.querySelectorAll("tbody tr")).filter(row => {
         const rowCheckbox = row.querySelector("input");
         return rowCheckbox.checked;
      }).map(row => {
         const properties = row.querySelectorAll("td>p");
         return {
            name: properties[0].textContent,
            price: Number(properties[1].textContent),
            decFactor: Number(properties[2].textContent),
         }
      });

      const output = `Bought furniture: ${selectedFurniture.map(e => e.name).join(", ")}\nTotal price: ${selectedFurniture.reduce((acc, curr) => {
         acc += curr.price;
         return acc;
      }, 0).toFixed(2)}\nAverage decoration factor: ${selectedFurniture.reduce((acc, curr) => {
         acc += curr.decFactor;
         return acc;
      }, 0) / selectedFurniture.length}`;

      const textarea = document.querySelectorAll("#exercise textarea")[1];

      textarea.value = output;
   });
}