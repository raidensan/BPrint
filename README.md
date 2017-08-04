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
  
  
# Road Map
* Execute printing in the thread
