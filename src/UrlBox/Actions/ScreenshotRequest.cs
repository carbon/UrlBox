using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

using UrlBox.Serialization;

namespace UrlBox;

public sealed class ScreenshotRequest
{
    [SetsRequiredMembers]
    public ScreenshotRequest(Uri url, string format = "png")
    {
        Url = url.ToString();
        Format = format;
    }

    public string Format { get; set; } // png, webp, jpg

    [DataMember(Name = "url")]
    public required string Url { get; set; }

    [DataMember(Name = "full_page")]
    public bool? FullPage { get; set; }

    [DataMember(Name = "media")]
    public string? Media { get; set; }

    [DataMember(Name = "selector")]
    public string? Selector { get; set; }

    [DataMember(Name = "width")]
    [DefaultValue(1280)]
    public int? Width { get; set; }

    [DataMember(Name = "height")]
    [DefaultValue(1024)] // unless full width
    public int? Height { get; set; }

    [DataMember(Name = "cookie")]
    public string? Cookie { get; set; }

    [DataMember(Name = "header")]
    public string? Header { get; set; }

    [DataMember(Name = "false")]
    public bool? Flash { get; set; }

    [DataMember(Name = "user_agent")]
    public string? UserAgent { get; set; }

    [DataMember(Name = "accept_lang")]
    [DefaultValue("en-US")]
    public string? AcceptLang { get; set; }

    [DataMember(Name = "authorization")]
    public string? Authorization { get; set; }

    [DataMember(Name = "proxy")]
    public string? Proxy { get; set; }

    [DataMember(Name = "latitude")]
    public double Latitude { get; set; }

    [DataMember(Name = "longitude")]
    public double Longitude { get; set; }

    [DataMember(Name = "accuracy")]
    public double Accuracy { get; set; }

    [DataMember(Name = "tz")]
    public string? Tz { get; set; }

    [DataMember(Name = "retina")]
    public bool? Retina { get; set; }

    [DataMember(Name = "thumb_width")]
    public int ThumbWidth { get; set; }

    [DataMember(Name = "crop_width")]
    public int CropWidth { get; set; }

    [DataMember(Name = "quality")]
    [DefaultValue(80)]
    public int? Quality { get; set; }

    [DataMember(Name = "transparent")]
    public bool? Transparent { get; set; }

    [DataMember(Name = "download")]
    public string? Download { get; set; }

    [DataMember(Name = "pdf_margin")]
    public int? PdfMargin { get; set; }

    [DataMember(Name = "pdf_page_size")]
    public int? PdfPageSize { get; set; }

    [DataMember(Name = "pdf_page_width")]
    public int? PdfPageWidth { get; set; }

    [DataMember(Name = "pdf_page_height")]
    public int? PdfPageHeight { get; set; }

    [DataMember(Name = "pdf_orientation")]
    public string? PdfOrientation { get; set; }

    [DataMember(Name = "pdf_auto_crop")]
    public bool? PdfAutoCrop { get; set; }

    /// <summary>
    /// Sets whether to print background images in the PDF
    /// </summary>
    [DataMember(Name = "pdf_background")]
    [DefaultValue(true)]
    public bool? PdfBackground { get; set; }

    [DataMember(Name = "force")]
    public bool? Force { get; set; }

    [DataMember(Name = "unique")]
    public string? Unique { get; set; }

    [DataMember(Name = "ttl")]
    public int Ttl { get; set; }

    [DataMember(Name = "wait_for")]
    public string? WaitFor { get; set; }

    [DataMember(Name = "wait_to_leave")]
    public string? WaitToLeave { get; set; }

    [DataMember(Name = "wait_timeout")]
    [DefaultValue(30_000)] // ms
    public TimeSpan? WaitTimeout { get; set; }

    /// <summary>
    /// Amount of time to wait in milliseconds before urlbox takes the screenshot or pdf
    /// </summary>
    [DataMember(Name = "delay")]
    [DefaultValue(0)]
    public TimeSpan? Delay { get; set; }

    /// <summary>
    /// Blocks requests from popular ad-networks from loading
    /// </summary>
    [DataMember(Name = "block_ads")]
    public bool? BlockAds { get; set; }

    /// <summary>
    /// Automatically hide cookie banners from most websites
    /// </summary>
    [DataMember(Name = "hide_cookie_banners")]
    public bool? HideCookieBanners { get; set; }

    [DataMember(Name = "disable_ligatures")]
    public bool? DisableLigatures { get; set; }

    /// <summary>
    /// Automatically click accept buttons in order to hide popups
    /// </summary>
    [DataMember(Name = "click_accept")]
    public bool? ClickAccept { get; set; }

    /// <summary>
    /// Element selector that is clicked before generating a screenshot or pdf e.g. #clickme would click the element with id="clickme".
    /// Can be used multiple times to simulate multiple sequential click events.
    /// </summary>
    [DataMember(Name = "click")]
    public string? Click { get; set; }

    [DataMember(Name = "hover")]
    public string? Hover { get; set; }

    [DataMember(Name = "bg_color")]
    public string? BgColor { get; set; }

    [DataMember(Name = "hide_selector")]
    public string? HideSelector { get; set; }

    /// <summary>
    /// Word to highlight on the page before capturing a screenshot or pdf
    /// </summary>
    [DataMember(Name = "highlight")]
    public string? Highlight { get; set; }

    /// <summary>
    /// Text color of the highlighted word
    /// </summary>
    [DataMember(Name = "highlightfg")]
    [DefaultValue("white")]
    public string? HighlightFg { get; set; }

    /// <summary>
    /// Background color of the highlighted word
    /// </summary>
    [DataMember(Name = "highlightbg")]
    [DefaultValue("red")]
    public string? HighlightBg { get; set; }

    [DataMember(Name = "allow_infinite")]
    public bool? AllowInfinite { get; set; }

    [DataMember(Name = "skip_scroll")]
    [DefaultValue(false)]
    public bool? SkipScroll { get; set; }

    [DataMember(Name = "detect_full_height")]
    public bool? DetectFullHeight { get; set; }

    [DataMember(Name = "max_section_height")]
    [DefaultValue(2098)]
    public int? MaxSectionHeight { get; set; }

    [DataMember(Name = "max_height")]
    public int? MaxHeight { get; set; }

    [DataMember(Name = "scroll_increment")]
    public int? ScrollIncrement { get; set; }

    [DataMember(Name = "scroll_delay")]
    public TimeSpan? ScrollDelay { get; set; }

    [DataMember(Name = "fail_if_selector_missing")]
    public bool? FailIfSelectorMissing { get; set; }

    [DataMember(Name = "fail_if_selector_present")]
    public bool? FailIfSelectorPresent { get; set; }

    [DataMember(Name = "fail_on_4xx")]
    public bool? FailOn4xx { get; set; }

    [DataMember(Name = "fail_on_5xx")]
    public bool? FailOn5xx { get; set; }

    [DataMember(Name = "timeout")]
    // [DefaultValue(30_000)] // in ms
    public TimeSpan? Timeout { get; set; }

    [DataMember(Name = "use_stealth", EmitDefaultValue = false)]
    public bool? UseStealth { get; set; }

    [DataMember(Name = "engine_version")]
    public string? EngineVersion { get; set; }

    public string ToQueryString()
    {
        var sb = new StringBuilder();

        foreach (var pair in GetParameters())
        {
            sb.Append(sb.Length is 0 ? '?' : '&');
            sb.Append(pair.Key);
            sb.Append('=');
            sb.Append(UrlEncode(pair.Value));
        }

        return sb.ToString();
    }

    // MATCH encodeURIComponent

    private static string UrlEncode(string text)
    {
        string result = Uri.EscapeDataString(text);

        result = result.Replace("%28", "(");
        result = result.Replace("%29", ")");

        return result;
    }

    private static readonly SerializedProperty[] s_properties = Serializer.GetProperties<ScreenshotRequest>();

    public IEnumerable<KeyValuePair<string, string>> GetParameters()
    {
        foreach (var property in s_properties)
        {
            object value = property.GetValue(this);

            if (value is null or 0 or 0d) continue;

            string fV = value switch
            {
                bool b => b ? "true" : "false",
                string s => s,
                TimeSpan t => ((int)t.TotalMilliseconds).ToString(CultureInfo.InvariantCulture),
                _ => value.ToString()!
            };

            yield return new(property.Name, fV);
        }
    }
}
