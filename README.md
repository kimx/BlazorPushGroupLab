# 說明
測試如何在Blazor整合SignalR，來通知特定群組

# 開發環境
* Visaul Studio 2022
* .Net Core 7
* Blazor Server

# 測試
* 登入後，選擇進入的班級
![image](https://github.com/kimx/BlazorPushGroupLab/assets/5724118/b70aa4d5-e230-44ed-a7af-2dd69969e6b5)

* 開另一瀏覽器視窗，針對特定班級發送訊息
![image](https://github.com/kimx/BlazorPushGroupLab/assets/5724118/7687d5fb-de8c-46a2-b2c5-42d9cb0c1514)

* 回到原本視窗，會收到通知訊息
 ![image](https://github.com/kimx/BlazorPushGroupLab/assets/5724118/74322f4b-a85e-4a25-99b1-9cfe93092c53)

# 參考文章
* [使用 ASP.NET Core SignalR 搭配 Blazor](https://learn.microsoft.com/zh-tw/aspnet/core/blazor/tutorials/signalr-blazor?view=aspnetcore-8.0&tabs=visual-studio)
* [在 SignalR 中管理使用者及群組](https://learn.microsoft.com/zh-tw/aspnet/core/signalr/groups?view=aspnetcore-8.0)
