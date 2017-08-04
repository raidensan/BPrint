# WirelessRawPrintHelper

A tiny helper library to extend raw priting on Windows CE based (CE, Embedded, Mobile etc.) devices. 

## Dependencies

.Net Compact Framework 2.0 or higher

## Quick Start
Download the binary and add it as Reference to your project.
Add using directive `using WirelessPrintHelper;`
Now you can use it:

### TcpIp
	private void TcpIpPrint(string ip, decimal port, FileInfo filename)
	{
		using (IWirelessPrinter btpHelper = new TcpIpPrinter(ip,(int)port))
		{
			btpHelper.Print(filename);
		}
	}
  
### Bluetooth SPP

	private void BtSppPrint(string port, FileInfo file)
	{
		using (IWirelessPrinter btpHelper = new BtSppPrinter(port))
		{
			btpHelper.Print(file);
		}
	}
  
## Sample

### A) Parameterized printing

This approach is susitable for payloads that are similar to each other. Consider the following CPCL command sets:

*Non-Parameterized*

	! 0 200 200 400 1
	LABEL
	CONTRAST 0
	TONE 0
	SPEED 3
	PAGE-WIDTH 400
	GAP-SENSE
	PREFEED 0
	POSTFEED 0
	PRESENT-AT 0 2
	T 7 0 10 10 My Sample Product
	T 7 0 10 40 PC-01
	BT 7 0 5
	B EAN13 2 1 100 7 80 8693332221117
	BT OFF
	FORM
	PRINT

*Parameterized*

	! 0 200 200 400 1
	LABEL
	CONTRAST 0
	TONE 0
	SPEED 3
	PAGE-WIDTH 400
	GAP-SENSE
	PREFEED 0
	POSTFEED 0
	PRESENT-AT 0 2
	T 7 0 10 10 <ProductName>
	T 7 0 10 40 <StockCode>
	BT 7 0 5
	B EAN13 2 1 100 7 80 <Barcode>
	BT OFF
	FORM
	PRINT

In parameterized version we have replaced values of our fields with a placeholder.

| Value | Placeholder |
|---|---|
| My Sample Product | \<ProductName\> |
| PC-01 | "<StockCode>" |
| 8693332221117 | "<Barcode>" |

By doing this we have created a template for our printing task. Now nefore printing we can dynamically set desired values.

    private byte[] PrepareContent(string filename)
    {
        // Prepare content parameters and their values
        // Parameters are <ProductName>, <StockCode> & <Barcode>
        // see afterParameterizing.LBL contents
        IContentParameters param = new ContentParameters();
        param.Add("<ProductName>", "My Sample Products");
        param.Add("<StockCode>", "PC-01");
        param.Add("<Barcode>", "8693332221117");

        // Read payload file
        IFileContentReader reader = new FileContentReader(filename);
        byte[] payload = reader.ReadAllAsByte();

        // Do the replacing
        IContentReplacer replacer = new ContentReplacer(param, Encoding.UTF8);
        return replacer.Replace(payload);
    }

See PrintSample_ParameterizedContent project for details.

# Road Map
* Execute printing in the thread
