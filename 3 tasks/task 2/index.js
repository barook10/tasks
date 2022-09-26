
function palindrome(inputString, trashString) {
    //using regEx ro remove unwanted characters
    let regExp = /[^A-Za-z0-9]/g
    inputString = inputString.toLowerCase().replace(regExp, '')
    //.replace will remove unwanted space eg: raceca r => racecar
    console.log("inputString:", inputString)
    console.log("TrashSymbolsString:", trashString)
    let len = inputString.length
    for (let i = 0; i < len/2; i++) {
      if (inputString[i] !== inputString[len - 1 - i]) {
          return "results should be: "+ false
      }
    }
    return "results should be: "+ true
   }
   
console.log(palindrome("RACEA R!@#", "!@#"))
