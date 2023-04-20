# 导入Tkinter模块
import tkinter as tk
from PIL import Image, ImageTk

# 创建一个窗口对象
window = tk.Tk()
window.title("图片窗口")

# 创建一个画布对象
canvas = tk.Canvas(window)

# 加载图片文件
image = Image.open("UserPyScripts/DefaultEasterEgg/Final Examination.png")

# 创建一个图片对象，用于在画布上显示
photo = ImageTk.PhotoImage(image)

# 获取图片的原始宽度和高度
original_width = photo.width()
original_height = photo.height()

# 定义一个函数，用于根据窗口的大小调整图片的大小和位置
def resize(event):
    # 获取窗口的当前宽度和高度
    window_width = event.width
    window_height = event.height

    # 计算图片的缩放比例，取宽度和高度中较小的一个
    scale = min(window_width / original_width, window_height / original_height)

    # 根据缩放比例重新计算图片的宽度和高度
    new_width = int(original_width * scale)
    new_height = int(original_height * scale)

    # 根据缩放比例重新生成图片对象
    global photo # 声明全局变量，否则会被垃圾回收
    photo = ImageTk.PhotoImage(image.resize((new_width, new_height)))

    # 删除画布上原有的图片
    canvas.delete("all")

    # 在画布上居中显示新的图片
    canvas.create_image(window_width / 2, window_height / 2, image=photo)

# 绑定窗口的大小变化事件，调用resize函数
window.bind("<Configure>", resize)

# 把画布添加到窗口上，并填充整个窗口
canvas.pack(fill="both", expand=True)

def main():

    # 启动窗口的主循环
    window.mainloop()

if __name__ == "__main__":
    main()
