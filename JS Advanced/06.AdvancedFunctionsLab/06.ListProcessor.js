// function solve(input) {
//     let result = [];

//     function add(str) {
//         result.push(str);
//     }

//     function remove(str) {
//         result = result.filter(e => e != str)
//     }

//     function print() {
//         console.log(result.join());
//     }

//     for (const item of input) {
//         const [command, value] = item.split(' ');

//         switch (command) {
//             case 'add':
//                 add(value);
//                 break;
//             case 'remove':
//                 remove(value);
//                 break;
//             case 'print':
//                 print();
//                 break;
//             default:
//                 break;
//         }
//     }
// }


//second decision
function solve(input) {
    let result = [];

    let commands = {
        add: str => result.push(str),
        remove: str => (result = result.filter(e => e !== str)),
        print: () => console.log(result.join())
    }

    input.forEach(str => {
        const [command, value] = str.split(' ');
        commands[command](value);
    })
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solve(['add pesho', 'add george', 'add peter', 'remove peter','print']);