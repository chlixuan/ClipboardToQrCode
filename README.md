# ClipboardToQrCode
借助二维码，帮你复制网址或文本到手机或平板。

Help you to Copy Url or Text from your PC to your Phone/Pad via  QrCode。

# 怎么使用/How to use




**步骤1**.电脑上按下ctrl+c复制网址或文本到剪切板

**Step1**.Press Ctrl + C on the computer to copy the web address or text to the clipboard

![image](https://raw.githubusercontent.com/chlixuan/ClipboardToQrCode/master/ClipboardToQrCode/steps/step1.jpg)

**步骤2**.点开程序，它会自动将剪切板中网址或文本转成二维码显示出来

**Step2**.Open this program, which will automatically display  a qr code containing the web address or text in the clipboard

![image](https://raw.githubusercontent.com/chlixuan/ClipboardToQrCode/master/ClipboardToQrCode/steps/step2.jpg)


**步骤3**.打开微信或浏览器扫码二维码

**Step3**.Open an app such as wechat or browser in your mobile devices to scan QR code

![image](https://raw.githubusercontent.com/chlixuan/ClipboardToQrCode/master/ClipboardToQrCode/steps/step3.jpg)

**步骤4**.在手机/平板式浏览页面

**Step4**.View page/text on your Phone/Pad

![image](https://raw.githubusercontent.com/chlixuan/ClipboardToQrCode/master/ClipboardToQrCode/steps/step-successful.jpg)


# 原理/How it works
程序从剪切板提取文本，将文本转换成二维码显示出来，手机扫二维码从而获得网址或文本。

生成二维码调用的是库 ThoughtWorks.QRCode 。

The program extracts text from the clipboard, converts the text into a QR code and displays it. Mobile devices such as mobile phones or pads scan the QR code to obtain the website address or text.

It is the library that generates the QR code ThoughtWorks.QRCode 。
