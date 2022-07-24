function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
   const input = document.querySelector('#inputs>textarea');
   const bestRestaurantP = document.querySelector('#bestRestaurant>p');
   const bestRestaurantWorkersP = document.querySelector('#workers>p');

   function onClick() {
      const arr = JSON.parse(input.value);
      let restaurants = {};

      arr.forEach((line) => {
         const tokens = line.split(' - ');
         const name = tokens[0];
         const workersArr = tokens[1].split(', ');
         let workers = [];

         for (const worker of workersArr) {
            const workerTokens = worker.split(' ');
            const salary = Number(workerTokens[1]);
            workers.push({ name: workerTokens[0], salary });
         }

         if (restaurants[name]) {
            workers = workers.concat(restaurants[name].workers);
         }

         workers.sort((a, b) => b.salary - a.salary);

         const bestSalary = workers[0].salary;
         const avgSalary = workers.reduce((sum, curr) => sum + curr.salary, 0) / workers.length;

         restaurants[name] = { workers, avgSalary, bestSalary };
      });

      let bestRestaurantAvgSalary = 0;
      let bestRestaurant = undefined;

      for (const name in restaurants) {
         if (restaurants[name].avgSalary > bestRestaurantAvgSalary) {
            bestRestaurantAvgSalary = restaurants[name].avgSalary;
            bestRestaurant = {
               name,
               workers: restaurants[name].workers,
               avgSalary: restaurants[name].avgSalary,
               bestSalary: restaurants[name].bestSalary
            };

            bestRestaurantAvgSalary = restaurants[name].avgSalary;
         }
      }

      bestRestaurantP.textContent = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.avgSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;

      let workersResult = [];
      bestRestaurant.workers.forEach((worker) => {
         workersResult.push(`Name: ${worker.name} With Salary: ${worker.salary}`)
      });
      bestRestaurantWorkersP.textContent = workersResult.join(' ');
   }
}