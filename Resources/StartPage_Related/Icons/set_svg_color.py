from xml.dom.minidom import parse
import json
import os

"""
读取 JSON 文件
获取颜色
格式:{
    "svg_files_color_setting": {
    "volume-down.svg" : "#000000",
    "volume-mute.svg": "#000000",
    "volume-off.svg": "#000000",
    "volume-up.svg": "#000000"
    }
}
"""


def get_color(py_current_path: str) -> dict:
    with open(py_current_path + 'volumn_svg_color.json', 'r') as f:
        json_content: dict = json.load(f)

    return json_content["svg_files_color_setting"]


# 更新 SVG（本质是XML） 文件的颜色
def update_SVGs(file_and_colors: dict, py_current_path: str) -> None:
    # 遍历字典， key 是文件名， value 是颜色， 例如：volume-down.svg : #000000
    for each_file, each_color in file_and_colors.items():
        # 纠正Unity工作目录
        each_file = py_current_path + each_file
        
        # 去除文件所有的缩进和换行，因为 minidom 会在写入文件时，自动添加缩进和换行
        remove_indent_and_newline(each_file)


        # 解析 SVG 文件
        dom_tree = parse(each_file)

        # 文档根元素
        rootNode = dom_tree.documentElement

        # 修改 color 属性
        rootNode.setAttribute('fill', each_color)

        # 写入文件
        with open(each_file, 'w') as f:
            # 带缩进，换行
            dom_tree.writexml(f, addindent='\t', newl='\n', encoding='utf-8')


# 去除文件所有的缩进和换行
def remove_indent_and_newline(file_name: str) -> None:
    with open(file_name, 'r') as f:
        content = f.read()

    with open(file_name, 'w') as f:
        f.write(content.replace('\n', '').replace('\t', ''))


def main(py_current_path: str) -> None:
    update_SVGs(get_color(py_current_path), py_current_path)
    
if __name__ == "__main__":
    main()
