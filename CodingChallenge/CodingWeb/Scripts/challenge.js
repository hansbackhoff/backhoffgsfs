function checkOpenClosed() {
    var code = document.getElementById("code");

    var text = code.value;

    return checkOpenClosedWithText(text);
}
function checkOpenClosedWithText(text) {
    var filoStack = [];
    
    for (let i = 0; i < text.length; i++) {

        //check for opening characters
        if (text[i] === '(' || text[i] === '{' || text[i] === '[') {
            filoStack.push(text[i]);
        }
        //check for opening characters
        else if (text[i] === ')' || text[i] === '}' || text[i] === ']') {
            var lastOpening = filoStack.pop();
            if (text[i] === ')' && lastOpening !== '(')
                return false;
            if (text[i] === '}' && lastOpening !== '{')
                return false;
            if (text[i] === ']' && lastOpening !== '[')
                return false;


        }

    }
    if (filoStack.length > 0)
        return false;
        
    return true;
}
function checkOpenClosedAlert() {
    if (checkOpenClosed()) {
        alert("Text is valid");
    }
    else alert("Text is not valid");
}


console.log(checkOpenClosedWithText("([((({()})))])"));
console.log(checkOpenClosedWithText("([((({()}))))"));

