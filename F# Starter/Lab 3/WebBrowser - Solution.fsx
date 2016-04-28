open System.Windows.Forms
open System.Net

// Creating a single form with a web browser control
let webClient = new WebClient()
let fsharpOrg = webClient.DownloadString("http://fsharp.org")
let browser = new WebBrowser(ScriptErrorsSuppressed = true, Dock = DockStyle.Fill, DocumentText = fsharpOrg)
let form = new Form(Text = "Hello from F#!")
form.Controls.Add(browser)
form.Show()

// As a function, refactored with tightly-defined value scopes
let showUrlInBrowser (url:string) : WebBrowser =
    let browser =
        let fsharpOrg =
            let webClient = new WebClient()
            webClient.DownloadString(url)
        new WebBrowser(ScriptErrorsSuppressed = true, Dock = DockStyle.Fill, DocumentText = fsharpOrg)
    let form = new Form(Text = "Hello from F#!")
    form.Controls.Add(browser)
    form.Show()
    browser

let theBrowser = showUrlInBrowser ("http://fsharp.org")

// function that updates the browser control with new content
let updateBrowserContent(newUrl:string, browser:WebBrowser) =
    let newContent =
        use webClient = new WebClient()
        webClient.DownloadString(newUrl)
    browser.DocumentText <- newContent

updateBrowserContent("http://fsprojects.github.io/", theBrowser)