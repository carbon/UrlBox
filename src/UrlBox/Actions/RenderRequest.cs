using System.Text.Json.Serialization;

namespace UrlBox;

public sealed class RenderRequest
{
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }

    [JsonPropertyName("html")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Html { get; set; }

    /// <summary>
    /// Specify whether to capture the full scrollable area of the website.
    /// For PDFs, full_page mode will attempt to capture the whole website onto one single page PDF document.
    /// default = false
    /// </summary>
    [JsonPropertyName("full_page")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool FullPage { get; set; }

    /// <summary>
    /// png | jpeg | webp | avif | svg | pdf | html | mp4 | webm | md
    /// </summary>
    [JsonPropertyName("format")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Format { get; set; }

    [JsonPropertyName("media")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Media { get; set; }

    /// <summary>
    /// Take a screenshot of the element that matches this selector.
    /// By default, if the selector is not found, Urlbox will take a normal viewport screenshot.
    /// </summary>
    [JsonPropertyName("selector")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Selector { get; set; }

    [JsonPropertyName("width")] // default = 1280
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Width { get; set; }

    [JsonPropertyName("height")] // default = 1024
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Height { get; set; }

    [JsonPropertyName("cookie")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Cookie { get; set; }

    /// <summary>
    /// Clip the screenshot to the bounding box specified by x,y,width,height.
    /// </summary>
    [JsonPropertyName("clip")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Clip { get; set; }

    /// <summary>
    /// Set a header on the request when loading the URL
    /// </summary>
    [JsonPropertyName("header")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Header { get; set; }

    /// <summary>
    /// Sets the User-Agent string for the request
    /// </summary>
    [JsonPropertyName("user_agent")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? UserAgent { get; set; }

    /// <summary>
    /// Sets an Accept-Language header on requests to the target URL
    /// default: en-US
    /// </summary>
    [JsonPropertyName("accept_lang")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? AcceptLang { get; set; }

    /// <summary>
    /// Sets an Authorization header on requests to the target URL.
    /// </summary>
    [JsonPropertyName("authorization")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Authorization { get; set; }

    [JsonPropertyName("proxy")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Proxy { get; set; }

    [JsonPropertyName("tz")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Tz { get; set; }

    /// <summary>
    /// Take a 'retina' or high-definition screenshot, equivalent to setting a device pixel ratio of 2.0 or @2x. 
    /// Please note that retina screenshots will be double the normal dimensions and will normally take slightly longer to process due to the much bigger image size.
    /// </summary>
    [JsonPropertyName("retina")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Retina { get; set; }

    /// <summary>
    /// The width of the generated thumbnail, in pixels. Omit for a full-size screenshot.
    /// </summary>
    [JsonPropertyName("thumb_width")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int ThumbWidth { get; set; }

    [JsonPropertyName("crop_width")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int CropWidth { get; set; }

    /// <summary>
    /// The image quality of the resulting screenshot (JPEG/WebP only)
    /// default: 80
    /// </summary>
    [JsonPropertyName("quality")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? Quality { get; set; }

    [JsonPropertyName("transparent")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool? Transparent { get; set; }

    [JsonPropertyName("download")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Download { get; set; }

    #region Pdf Options

    /// <summary>
    /// Sets the margin of the PDF document.
    /// none | default | minimum
    /// </summary>
    [JsonPropertyName("pdf_margin")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PdfMargin { get; set; }

    [JsonPropertyName("pdf_margin_top")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? PdfMarginTop { get; set; }

    [JsonPropertyName("pdf_margin_right")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? PdfMarginRight { get; set; }

    [JsonPropertyName("pdf_margin_left")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? PdfMarginLeft { get; set; }

    [JsonPropertyName("pdf_margin_bottom")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? PdfMarginBottom { get; set; }

    /// <summary>
    /// Setting this option will take precedence over pdf_page_width and pdf_page_height.
    /// A0 | A1 | A2 | A3 | A4 | A5 | A6 | Legal | Letter | Ledger | Tabloid
    /// default: A4
    /// </summary>
    [JsonPropertyName("pdf_page_size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PdfPageSize { get; set; }

    /// <summary>
    /// Sets the PDF page range to return.
    /// </summary>
    [JsonPropertyName("pdf_page_range")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PdfPageRange { get; set; }

    /// <summary>
    /// Sets the PDF page width, in pixels
    /// </summary>
    [JsonPropertyName("pdf_page_width")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int PdfPageWidth { get; set; }

    /// <summary>
    /// Sets the PDF page height, in pixels
    /// </summary>
    [JsonPropertyName("pdf_page_height")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int PdfPageHeight { get; set; }

    /// <summary>
    /// portrait landscape
    /// default = portrait
    /// </summary>
    [JsonPropertyName("pdf_orientation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PdfOrientation { get; set; }

    /// <summary>
    /// Automatically remove white space from PDF.
    /// Occasionally a PDF will have a lot of trailing white space at the bottom of the page.
    /// This option will attempt to automatically crop the PDF to remove this white space.
    /// </summary>
    [JsonPropertyName("pdf_auto_crop")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool PdfAutoCrop { get; set; }

    /// <summary>
    /// Sets whether to print background images in the PDF
    /// default = true
    /// </summary>
    [JsonPropertyName("pdf_background")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool? PdfBackground { get; set; }

    #endregion

    #region Wait Options

    /// <summary>
    /// Amount of time to wait in milliseconds before urlbox takes the screenshot or pdf
    /// default = 0
    /// </summary>
    [JsonPropertyName("delay")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Delay { get; set; }

    /// <summary>
    /// The amount of time to wait for the requested URL to load, in milliseconds.
    /// The timeout value needs to be between 5,000 and 100,000 milliseconds.
    /// default: 30000 (30 seconds)
    /// </summary>
    [JsonPropertyName("timeout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Timeout { get; set; }

    /// <summary>
    /// Waits for the element specified by this selector to be present in the DOM before taking a screenshot or pdf
    /// By default, Urlbox will take a screenshot or PDF if the wait_for element is not found after waiting for the time specified by the wait_timeout option.
    /// </summary>
    [JsonPropertyName("wait_for")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WaitFor { get; set; }

    /// <summary>
    /// Waits until the specified DOM event has fired before capturing a render.
    /// The available options are:
    /// - domloaded (the DOMContentLoaded event is fired)
    /// - mostrequestsfinished (consider navigation to be finished when there are no more than 2 network connections for at least 500 ms)
    /// - requestsfinished (there are no more than 0 network connections for at least 500 ms)
    /// - loaded (the load event is fired)      
    /// default: loaded
    /// </summary>
    [JsonPropertyName("wait_until")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WaitUntil { get; set; }

    /// <summary>
    /// Waits for the element specified by this selector to be absent from the DOM before taking a screenshot or PDF.
    /// </summary>
    [JsonPropertyName("wait_to_leave")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WaitToLeave { get; set; }

    /// <summary>
    /// The amount of time to wait for the wait_for element to appear, or the wait_to_leave element to leave before continuing, in milliseconds
    /// default: 30000
    /// </summary>
    [JsonPropertyName("wait_timeout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? WaitTimeout { get; set; }

    #endregion

    [JsonPropertyName("force")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Force { get; set; }

    /// <summary>
    /// Pass a unique string such as a UUID, hash or timestamp, to have more control over when to generate a fresh screenshot or PDF.
    /// </summary>
    [JsonPropertyName("unique")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Unique { get; set; }

    /// <summary>
    /// The duration to keep a screenshot or PDF in the cache, in seconds. ttl stands for 'time to live'. 
    /// he default value is also the maximum value: 2592000 seconds (30 days).
    /// default = 2592000
    /// </summary>
    [JsonPropertyName("ttl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Ttl { get; set; }

    /// <summary>
    /// Automatically hides cookie banners from most websites, by setting their style to display: none !important;
    /// </summary>
    [JsonPropertyName("hide_cookie_banners")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool HideCookieBanners { get; set; }

    [JsonPropertyName("disable_ligatures")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool DisableLigatures { get; set; }

    /// <summary>
    /// Automatically click accept buttons in order to hide popups
    /// </summary>
    [JsonPropertyName("click_accept")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool ClickAccept { get; set; }

    /// <summary>
    /// Element selector that is clicked before generating a screenshot or pdf e.g. #clickme would click the element with id="clickme".
    /// Can be used multiple times to simulate multiple sequential click events.
    /// </summary>
    [JsonPropertyName("click")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Click { get; set; }

    [JsonPropertyName("hover")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Hover { get; set; }

    [JsonPropertyName("bg_color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BgColor { get; set; }

    /// <summary>
    /// Comma-delimited string of CSS element selectors that are hidden by setting their style to display: none !important;.
    /// Useful for hiding pop-ups.
    /// </summary>
    [JsonPropertyName("hide_selector")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? HideSelector { get; set; }

    #region Blocking Options

    /// <summary>
    /// Blocks requests from popular ad-networks from loading
    /// </summary>
    [JsonPropertyName("block_ads")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool BlockAds { get; set; }

    /// <summary>
    /// Block requests from specific domains from loading.
    /// You can use wildcard characters such as * to match subdomains.
    /// </summary>
    [JsonPropertyName("block_urls")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? BlockUrls { get; set; }

    /// <summary>
    /// Blocks image requests
    /// </summary>
    [JsonPropertyName("block_images")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool BlockImages { get; set; }

    /// <summary>
    /// Blocks font requests
    /// </summary>
    [JsonPropertyName("block_fonts")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool BlockFonts { get; set; }

    /// <summary>
    /// Blocks font requests
    /// </summary>
    [JsonPropertyName("block_medias")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool BlockMedias { get; set; }

    /// <summary>
    /// Prevent requests for javascript scripts from loading
    /// </summary>
    [JsonPropertyName("block_scripts")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool BlockScripts { get; set; }

    /// <summary>
    /// Blocks frames
    /// </summary>
    [JsonPropertyName("block_frames")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool BlockFrames { get; set; }

    /// <summary>
    /// Block fetch requests from the target URL
    /// </summary>
    [JsonPropertyName("block_fetch")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool BlockFetch { get; set; }

    /// <summary>
    /// Block fetch requests from the target URL
    /// </summary>
    [JsonPropertyName("block_xhr")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool BlockXhr { get; set; }

    /// <summary>
    /// Block websocket requests
    /// </summary>
    [JsonPropertyName("block_sockets")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool BlockSockets { get; set; }

    #endregion

    /// <summary>
    /// Execute custom JavaScript in the context of the page.
    /// The JS gets executed after the page's dom has loaded, but before the screenshot is taken.
    /// No need to use load etc event handlers to run code, as these events will already have fired by the time this JS gets executed.
    /// You can use await to wait for promises to resolve.
    /// </summary>
    [JsonPropertyName("js")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? JS { get; set; }

    /// <summary>
    /// Inject custom CSS into the page
    /// </summary>
    [JsonPropertyName("css")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CSS { get; set; }

    #region Full Page Options

    /// <summary>
    /// Whether to use scroll and stitch algorithm (the default) to render a full page screenshot, or to use the native full page screenshot algorithm, which is faster, but can be less accurate on some sites.
    /// stitch | native
    /// default = stitch
    /// </summary>
    [JsonPropertyName("full_page_mode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FullPageMode { get; set; }

    /// <summary>
    /// By default, when Urlbox detects an infinite scrolling page, it does not attempt to continue scrolling to the bottom, as this could result in infinite scrolling! 
    /// If you want to override this behaviour, pass true for this option.
    /// </summary>
    [JsonPropertyName("allow_infinite")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool AllowInfinite { get; set; }

    /// <summary>
    /// Enabling skip_scroll will speed up renders by skipping an initial scroll through the page, which is used to trigger any lazy loading elements.
    /// </summary>
    [JsonPropertyName("skip_scroll")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool SkipScroll { get; set; }

    /// <summary>
    /// Some pages have full-height backgrounds whose heights are set to 100% of the viewport.
    /// This can cause the backgrounds to get stretched when making a full page screenshot.
    /// If you are seeing this behavior in your full page screenshots, pass true for this option.
    /// </summary>
    [JsonPropertyName("detect_full_height")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool DetectFullHeight { get; set; }

    /// <summary>
    /// default = 2098
    /// </summary>
    [JsonPropertyName("max_section_height")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxSectionHeight { get; set; }

    /// <summary>
    /// Sets how many pixels to scroll when scrolling the page to trigger lazy loading elements.
    /// By default, the scroll increment is set to the browser viewport height.
    /// Some pages' lazy loading elements only trigger when the scroll increment is smaller than this, however, e.g. 400px.
    /// </summary>
    [JsonPropertyName("scroll_increment")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ScrollIncrement { get; set; }

    /// <summary>
    /// When Urlbox decides to split a screenshot into multiple sections, the scroll delay is the time to wait between taking the screenshots of each individual section, in milliseconds.
    /// While Urlbox does detect animations, and attempts to wait for them before taking a screenshot, this option could be used to force Urlbox to wait for a certain amount of time after scrolling to the next section, to wait for things like animations to finish.
    /// </summary>
    [JsonPropertyName("scroll_delay")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int ScrollDelay { get; set; }

    #endregion

    #region Highlighting Options

    /// <summary>
    /// Word to highlight on the page before capturing a screenshot or pdf
    /// </summary>
    [JsonPropertyName("highlight")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Highlight { get; set; }

    /// <summary>
    /// Text color of the highlighted word
    /// </summary>
    [JsonPropertyName("highlightfg")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? HighlightFg { get; set; }

    /// <summary>
    /// Background color of the highlighted word
    /// </summary>
    [JsonPropertyName("highlightbg")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? HighlightBg { get; set; }

    #endregion

    /// <summary>
    /// Emulate dark mode on websites by setting prefers-color-scheme: dark
    /// </summary>
    [JsonPropertyName("dark_mode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool DarkMode { get; set; }

    /// <summary>
    /// Make the pdf into a readable document by removing unnecessary elements such as navigation bars, ads, etc.
    /// </summary>
    [JsonPropertyName("readable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Readable { get; set; }

    /// <summary>
    /// Prefer less animations on websites by setting prefers-reduced-motion: reduced
    /// </summary>
    [JsonPropertyName("reduced_motion")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool ReducedMotion { get; set; }

    [JsonPropertyName("max_height")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxHeight { get; set; }

    #region Fail Options

    /// <summary>
    /// Fails the request if the elements specified by selector or wait_for options are not found on the page after waiting for wait_timeout.
    /// default = false
    /// </summary>
    [JsonPropertyName("fail_if_selector_missing")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool FailIfSelectorMissing { get; set; }

    /// <summary>
    /// Fails the request if the element specified by wait_to_leave option is found on the page after waiting for wait_timeout.
    /// default = false
    /// </summary>
    [JsonPropertyName("fail_if_selector_present")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool FailIfSelectorPresent { get; set; }

    /// <summary>
    /// If fail_on_4xx=true and the requested URL returns a status code between 400 and 499, Urlbox will fail the request with error code 400 and the message: Failed to render. Requested URL returned a 4xx error code and fail_on_4xx was true
    /// default = false
    /// </summary>
    [JsonPropertyName("fail_on_4xx")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool FailOn4xx { get; set; }

    /// <summary>
    /// If fail_on_5xx=true and the requested URL returns a status code between 500 and 599, Urlbox will fail the request with error code 400 and message: Failed to render. Requested URL returned a 5xx error code and fail_on_5xx was true
    /// default = false
    /// </summary>
    [JsonPropertyName("fail_on_5xx")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool FailOn5xx { get; set; }

    #endregion

    #region Geocode Options

    [JsonPropertyName("latitude")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public double Longitude { get; set; }

    /// <summary>
    /// Sets the accurate of the Geolocation API, in metres
    /// </summary>
    [JsonPropertyName("accuracy")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Accuracy { get; set; }

    #endregion


    #region Storage Options

    [JsonPropertyName("use_s3")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool UseS3 { get; set; }

    [JsonPropertyName("s3_path")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? S3Path { get; set; }

    [JsonPropertyName("s3_bucket")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? S3Bucket { get; set; }

    [JsonPropertyName("s3_endpoint")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? S3Endpoint { get; set; }

    [JsonPropertyName("s3_region")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? S3Region { get; set; }

    [JsonPropertyName("cdn_host")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CdnHost { get; set; }

    [JsonPropertyName("s3_storageclass")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? S3StorageClass { get; set; }

    #endregion

    [JsonPropertyName("gpu")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Gpu { get; set; }

    /// json | binary
    // [JsonPropertyName("response_type")]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // public string? ResponseType { get; set; }
}