function solve() {
   const sentences = Array.from(document.querySelector("#input").value.split(".").filter(element => {
      if (element !== "") {
         return true;
      }
   }));
   const remainder = sentences.length % 3;

   const paragraphs = []; 

   console.log(sentences);

   if (sentences.length < 3) {
      const paragraph = document.createElement("p");
      paragraph.textContent = sentences.join(".") + ".";

      paragraphs.push(paragraph);
   } else {
      for (let i = 0; i < sentences.length - remainder; i += 3) {
         const paragraph = document.createElement("p");
         paragraph.textContent = sentences.slice(i, i + 3).join(".") + ".";

         paragraphs.push(paragraph);
      }
   
      if (remainder !== 0 && sentences.length > 3) {
         const paragraph = document.createElement("p");
         paragraph.textContent = sentences.slice(sentences.length - remainder, sentences.length).join(".") + ".";
         
         console.log(paragraph.textContent);

         paragraphs.push(paragraph);
      }
   }

   const output = document.querySelector("#output");
   output.innerHTML = "";

   paragraphs.forEach(paragraph => {
      output.appendChild(paragraph);
   });
}