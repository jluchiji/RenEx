#RenEx

Powerful and sometimes automagical file renaming utility.   
RenEx is licensed under the MIT License. Full license can be found [here](LICENSE.md)

##Features
###Organize your files in batches
RenEx allows you to rename of move your files in batches of any size. You can rename all your files in just one session, no matter how complex their names are. You can preview every change you make, and RenEx detects some errors for you.

###Smart recognition of file names and extensions
RenEx uses *Extended IO Framework* of *libWyvernzora* that allows it to separate file names from extensions in a smarter way. No need to say that RenEx supports multiple extensions, and allows you to rename them as well.

###Flexible rule system
You define **rules** that specify how to rename files, and RenEx renames them for you! You can define as many rules as you need, so that every file and every corner case of your renaming needs is covered. There are separate rules for file names and file extensions. You can apply rules to the directory paths as well, in effect moving your files around!

###Templates: Reuse your work
You can save your rules and extension settings so that you can reuse them later in a few clicks. I am currently working on a way to reuse Regex snippets and other bits and pieces.



##Notes
**RenEx** was never meant to be a *drag-and-done* type of utility. You need in-depth knowledge of Regular Expressions to utilize it to its full potential. Be careful using this software if you don't feel comfortable debugging regular expressions, because if you apply a wrong rule it may mess up your files in a bad way. The software does not provide a way to reverse changes made by it.

**RenEx** is based on **libWyvernzora**, my personal library, which is not open source at the moment. Icons and artwork used in the project are by [Takegawa Shin](http://www.pixiv.net/member.php?id=201634).

As of May 14, 2013 the project (version 0.9) is still work in progress. It works, but a lot of convenience elements and AI are still missing.

##Dependencies
This project depends on my personal library, **libWyvernzora**. It is updated via my personal NuGet feed, in order to acquire the package please add the following NuGet feed to your VisualStudio:
`http://www.myget.org/F/wyvernzora/`
