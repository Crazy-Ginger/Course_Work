function distance(x, y) {

}

function solution(destinaitions) {
    if (destinations.length < 7) {
        for (i = 0; i < 10; i++){

        }
    }
}

var permArr = [],
    usedChars = [];

function permute(input) {
    var i, ch;
    var j = 0;
    for (i = 0; i < input.length; i++) {
        j += 1;
        ch = input.splice(i, 1)[0];
        usedChars.push(ch);
        if (input.length === 0) {
            permArr.push(usedChars.slice());
        }
        permute(input);
        input.splice(i, 0, ch);
        usedChars.pop();
    }
    return permArr, j
};

document.write(JSON.stringify(permute([1, 2, 3, 4])));