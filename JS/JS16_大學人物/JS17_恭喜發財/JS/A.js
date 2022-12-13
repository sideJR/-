import { WesternYear as year, country as CTY, eng_country, GetMoney as Get } from '/JS/B.js'

let x = "<h3>" + CTY + "(" + eng_country + ")" + year + "新年快樂" + "</h3>";
let y = "<h4 style='color:red'> " + Get("叔叔") + "。" + Get("表妹");

document.getElementById('Q').innerHTML = x + y;