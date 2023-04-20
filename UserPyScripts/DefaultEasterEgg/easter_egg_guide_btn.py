import webbrowser


easter_egg_url = "https://www.hku.hk/"

def open_url(url: str) -> None:
    webbrowser.open(url)


def open_url_hku_homepage() -> None:
    open_url(easter_egg_url)



