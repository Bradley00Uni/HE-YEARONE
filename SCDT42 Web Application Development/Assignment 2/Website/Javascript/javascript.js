//Based on the current day, the corsponding opening time information is displayed

var todayMonday = "<font color='#980000'>MONDAY 10:00 - LATE</font>";
var todayTuesday = "<font color='#980000'>TUESDAY 10:00 - LATE</font>";
var todayWednesday = "<font color='#980000'>WEDNESDAY 10:00 - LATE</font>";
var todayThursday = "<font color='#980000'>THURSDAY 10:00 - LATE</font>";
var todayFriday = "<font color='#980000'>FRIDAY 10:00 - LATE</font>";
var todaySaturday = "<font color='#980000'>SATURDAY 10:00 - LATE</font>";
var todaySunday = "<font color='#980000'>SUNDAY 10:00 - LATE</font>";

switch (new Date().getDay()) {
    case 0:
        document.getElementById("opening-times").innerHTML = "<b>MONDAY 10:00 - LATE <br>TUESDAY 10:00 - LATE<br>WEDNESDAY 10:00 - LATE <br>THURSDAY 10:00 - LATE <br>FRIDAY 10:00 - LATE <br>SATURDAY 10:00 - LATE <br></b>" + todaySunday;
        break;
    case 1:
        document.getElementById("opening-times").innerHTML = todayMonday + "<b><br>TUESDAY 10:00 - LATE <br>WEDNESDAY 10:00 - LATE <br>THURSDAY 10:00 - LATE <br>FRIDAY 10:00 - LATE <br>SATURDAY 10:00 - LATE <br>SUNDAY 10:00 - LATE</b>";
        break;
    case 2:
        document.getElementById("opening-times").innerHTML = "<b>MONDAY 10:00 - LATE<br>" + todayTuesday + "<br>WEDNESDAY 10:00 - LATE <br>THURSDAY 10:00 - LATE <br>FRIDAY 10:00 - LATE <br>SATURDAY 10:00 - LATE <br>SUNDAY 10:00 - LATE</b>";
        break;
    case 3:
        document.getElementById("opening-times").innerHTML = "<b>MONDAY 10:00 - LATE <br>TUESDAY 10:00 - LATE<br>" + todayWednesday + " <br>THURSDAY 10:00 - LATE <br>FRIDAY 10:00 - LATE <br>SATURDAY 10:00 - LATE <br>SUNDAY 10:00 - LATE</b>";
        break;
    case 4:
        document.getElementById("opening-times").innerHTML = "<b>MONDAY 10:00 - LATE <br>TUESDAY 10:00 - LATE<br>WEDNESDAY 10:00 - LATE <br>" + todayThursday + " <br>FRIDAY 10:00 - LATE <br>SATURDAY 10:00 - LATE <br>SUNDAY 10:00 - LATE</b>";
        break;
    case 5:
        document.getElementById("opening-times").innerHTML = "<b>MONDAY 10:00 - LATE <br>TUESDAY 10:00 - LATE<br>WEDNESDAY 10:00 - LATE <br>THURSDAY 10:00 - LATE <br>" + todayFriday + " <br>SATURDAY 10:00 - LATE <br>SUNDAY 10:00 - LATE</b>";
        break;
    case 6:
        document.getElementById("opening-times").innerHTML = "<b>MONDAY 10:00 - LATE <br>TUESDAY 10:00 - LATE<br>WEDNESDAY 10:00 - LATE <br>THURSDAY 10:00 - LATE <br>FRIDAY 10:00 - LATE <br>" + todaySaturday + " <br>SUNDAY 10:00 - LATE</b>";
        break;
}
