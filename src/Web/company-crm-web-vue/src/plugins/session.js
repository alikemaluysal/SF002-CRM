export default {
    setSession: function (data) {
        window.localStorage.setItem("token", JSON.stringify(data));
    },
    getSession: function () {
        return JSON.parse(window.localStorage.getItem("token"));
    },
    needsAuthentication: function () {
        let accessToken = window.localStorage.getItem("token");
        if (!accessToken) {
            return true;
        }
        return false;
    },
    isLoggedIn: function () {
        return !this.needsAuthentication()
    }
}