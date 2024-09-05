function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   
   function onClick() {
      const rows = Array.from(document.querySelectorAll("tbody>tr")).map(row => {
         return Array.from(row.querySelectorAll("td"));
      });

      const searchInput = document.querySelector("#searchField").value;

      for (const row of rows) {
         let rowMatched = false;

         for (const cell of row) {
            if (cell.textContent.includes(searchInput)) {
               rowMatched = true;
               break;
            }
         }

         if (rowMatched) {
            row[0].parentElement.className = "select";
         } else {
            row[0].parentElement.className = "";
         }
      }

      document.querySelector("#searchField").value = "";
   }
}