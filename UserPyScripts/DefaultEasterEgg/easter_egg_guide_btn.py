import webbrowser

# 重要：本脚本引用的所有路径必须以该Unity项目的根目录为相对路径

easter_egg_url = "https://www.hku.hk/"

def open_url(url: str) -> None:
    webbrowser.open(url)


def open_url_hku_homepage() -> None:
    open_url(easter_egg_url)



