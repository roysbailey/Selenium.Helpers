Selenium.RecursiveElement.Sample
================================

Following a nightmare experience testing a COTS website which was riddled with nested frames and iframes I decided to write a simple helper to ease the pain of trying to work back the frame / iframe ancestory for every element I needed to access, and then having to litter my POM classes with lots of SwitchTo().Frame("XYZ").

So, I developed the an extension method to complement the existing FindElement method.  The new method is called FindElementRecursive.  The method signature is identical to the original, and the only difference is that the extension method recursively iterates over all frames and iframes until it finds a match.

Obviously, if you have the same element (ID) in > 1 frame, it will match the first one, which may not be what you want.  We found such instances to be few and far between in our use case, but if you do hit that issue, you are back to the "out the box" Selenium option (and switching frames yourself)

The Solution includes three Projects:

* Selenium.Helpers - this contains the FindElementRecursive extension method
* WebSitePOM - the Page Object Model (to provide a clean, Selenium free interface to the test project)
* Tests - MSTest sample test which uses a local "test website" (under "sut" folder) to show how it works with Frames and IFrames.

Enjoy!