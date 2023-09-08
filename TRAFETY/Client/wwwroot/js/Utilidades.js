function timerInactivo(dotnetHelper) {
    var timer;
    document.onmousemove = resetTimer;
    document.onkeypress = resetTimer;

    function resetTimer() {
        clearTimeout(timer);
        //timer = setTimeout(logout, 3*1000) // 3 segundos
    }

    function logout() {
        dotnetHelper.invokeMethodAsync("Logout");
    }
}