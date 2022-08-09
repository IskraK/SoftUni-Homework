function solve(command) {
    if (command === 'upvote') {
        return this.upvotes++;
    } else if (command === 'downvote') {
        return this.downvotes++;
    }

    let upvote = this.upvotes;
    let downvote = this.downvotes;
    let totalVotes = upvote + downvote;
    let balance = upvote - downvote;

    function rating() {
        if (totalVotes < 10) {
            return 'new';
        } else if (upvote > totalVotes * 0.66) {
            return 'hot';
        } else if (balance >= 0 && totalVotes > 100) {
            return 'controversial';
        } else if (balance < 0) {
            return 'unpopular';
        } else {
            return 'new';
        }
    }

    if (totalVotes > 50) {
        let inflateVote = Math.ceil(Math.max(upvote, downvote) * 0.25);
        return [upvote + inflateVote, downvote + inflateVote, balance, rating()];
    }

    return [upvote, downvote, balance, rating.call(this)];
}

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};
solve.call(post, 'upvote');
solve.call(post, 'downvote');
let score = solve.call(post, 'score'); // [127, 127, 0, 'controversial']
console.log(score);
solve.call(post, 'downvote');         // (executed 50 times)
score = solve.call(post, 'score');     // [139, 189, -50, 'unpopular']
console.log(score);


// //second decision
// function monkeyPatcher(command) {
//     function statusChecker(upvote, downvote, balance) {
//         let status = '';
//         const total = upvote + downvote;
//         const positiveVotes = (upvote / total) * 100;

//         if (total < 10) {
//             status = 'new';
//         } else if (positiveVotes > 66) {
//             status = 'hot';
//         } else if (positiveVotes >= 50 && positiveVotes <= 66 && balance >= 0 && total > 100) {
//             status = 'controversial';
//         } else if (balance < 0) {
//             status = 'unpopular';
//         } else {
//             status = 'new';
//         }

//         return status;
//     }

//     const ratingManipulator = {
//         upvote: () => this.upvotes += 1,
//         downvote: () => this.downvotes += 1,
//         score: () => {
//             let status = '';
//             let inflated = 0;
//             if (this.upvotes + this.downvotes > 50) {
//                 inflated = Math.ceil(Math.max(this.upvotes, this.downvotes) * 0.25);
//             }
//             const upvotes = this.upvotes + inflated;
//             const downvotes = this.downvotes + inflated;
//             const balance = this.upvotes - this.downvotes;

//             status = statusChecker(this.upvotes, this.downvotes, balance);

//             return [upvotes, downvotes, balance, status];
//         }
//     }

//     return ratingManipulator[command](this);
// }

// let post = {
//     id: '3',
//     author: 'emil',
//     content: 'wazaaaaa',
//     upvotes: 100,
//     downvotes: 100
// };

// monkeyPatcher.call(post, 'upvote');
// monkeyPatcher.call(post, 'downvote');
// let score = monkeyPatcher.call(post, 'score'); // [127, 127, 0, 'controversial']
// console.log(score);
// monkeyPatcher.call(post, 'downvote');        // (executed 50 times)
// score = monkeyPatcher.call(post, 'score');     // [139, 189, -50, 'unpopular']
// console.log(score);