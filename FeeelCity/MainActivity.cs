using Android.Runtime;
using Android.Views;
using Android.Webkit;

namespace FeeelCity;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    private LogCafe<MainActivity>? _log;
    private WebView? _webView;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        try
        {
            _log = new LogCafe<MainActivity>();
            _log.Info("Start app CafeRu");
            base.OnCreate(savedInstanceState);
            SetTheme(Resource.Style.CafeRuTheme);
            SetContentView(Resource.Layout.activity_main);
            Init();
        }
        catch (Exception er)
        {
            _log?.Error(er);
            Toast.MakeText(this, "Вы потерпели фиаско", ToastLength.Long)?.Show();
        }
    }

    private void Init()
    {
        _webView = FindViewById<WebView>(Resource.Id.webView);
        if (_webView == null)
            throw new ArgumentNullException(nameof(_webView));
        _webView.SetWebViewClient(new WebViewClientClass());
        _webView.Settings.JavaScriptEnabled = true;
        _webView.LoadUrl(Constants.PointUrl);
    }

    public override bool OnKeyDown(Keycode keyCode, KeyEvent? e)
    {
        if (_webView != null && keyCode == Keycode.Back && _webView.CanGoBack())
        {
            _webView.GoBack();
            return true;
        }
        return base.OnKeyDown(keyCode, e);
    }

    class WebViewClientClass : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView? view, IWebResourceRequest? request)
        {
            view?.LoadUrl(request?.Url?.ToString() ?? string.Empty);
            return false;
        }
    }


    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
    {
        Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }
}