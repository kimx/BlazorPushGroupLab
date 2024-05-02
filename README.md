# 說明
測試如何在Blazor整合SignalR，來通知特定群組

# 開發環境
* Visaul Studio 2022
* .Net Core 7
* Blazor Server

# 測試
* 登入後，選擇進入的班級
  ![image](https://github.com/kimx/BlazorSignalRGroupLab/assets/5724118/38c27323-8d41-4db9-b43f-047cbcf179f2)

* 開另一瀏覽器視窗，針對特定班級發送訊息
  ![image](https://github.com/kimx/BlazorSignalRGroupLab/assets/5724118/5f7f767b-67d9-4932-928c-d82c1c3d5eaa)

* 回到原本視窗，會收到通知訊息
![image](https://github.com/kimx/BlazorSignalRGroupLab/assets/5724118/46d52a56-d905-424b-8c35-1f3892b97c04)

# 參考文章
* [使用 ASP.NET Core SignalR 搭配 Blazor](https://learn.microsoft.com/zh-tw/aspnet/core/blazor/tutorials/signalr-blazor?view=aspnetcore-8.0&tabs=visual-studio)
* [在 SignalR 中管理使用者及群組](https://learn.microsoft.com/zh-tw/aspnet/core/signalr/groups?view=aspnetcore-8.0)
