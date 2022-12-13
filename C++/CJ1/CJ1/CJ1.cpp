#include <iostream> //08130263 蔡孟臻

using namespace std;
//卜算子 宋朝李之儀

void ShowTopic();   //Overloading
void ShowTopic(string Title, string Author);   //如果將函數放在呼叫者後面，需先在前面寫出函數名稱

int main()
{
    string title, author;
    cin >> title;   //輸入標題
    cin >> author;  //輸入作者

    // string River[3] = {"基隆河", "新店溪", "大漢溪"}, Water[3] = {"翡翠水庫", "翡翠水庫", "石門水庫"}; 輸入的順序
    string River[3], Water[3];

    int i = 0;

    //使用while讀取輸入資料
    while (i < 3)
    {
        cin >> River[i];    //輸入河流
        cin >> Water[i];    //輸入水庫
        i++;
    }

    ShowTopic(title, author);

    i = 0;

    //使用do...while輸出
    do
    {
        cout << "我住" << River[i] << "頭\n"; //output
        cout << "君住" << River[i] << "尾\n";
        cout << "共飲" << Water[i] << "水\n";
        cout << "\n";

        i += 1;
    } while (i < 3);


}

//函數放在呼叫者後面發生錯誤
void ShowTopic(string Title, string Author)
{
    cout << "台灣新詩\n";
    cout << "題目：" << Title << "\n";
    cout << "作者：" << Author << "\n\n";
}
