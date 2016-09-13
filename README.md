#ph-genericode

[![Dependencies](https://www.versioneye.com/user/projects/5641ff234d415e001b00070c/badge.svg?style=flat)](https://www.versioneye.com/user/projects/5641ff234d415e001b00070c)

Java library for reading and writing OASIS GeneriCode and CVA files.
It supports GeneriCode 0.4 and GeneriCode 1.0 as well as CVA 1.0.

#News and noteworthy
  
  * v5.0.1
    * Added new package `com.helger.genericode.builder` with more flexible marshaller
  * v5.0.0
    * Requires JDK 8
    * Binds to ph-commons 8.x
  * v4.1.1
    * Last version with JDK 6 support
  * v4.0.0
    * Binds to ph-commons 6.x
  * v3.3.1
    * Binds to ph-commons 5.x      

#Usage with Maven
```xml
<dependency>
  <groupId>com.helger</groupId>
  <artifactId>ph-genericode</artifactId>
  <version>5.0.0</version>
</dependency>
```

Technically this library requires [ph-commons](https://github.com/phax/ph-commons) and optionally [ph-poi](https://github.com/phax/ph-poi) for Excel file handling.

#Examples

[Example code for reading GeneriCode v0.4 CodeList files](https://github.com/phax/ph-genericode/blob/master/src/test/java/com/helger/genericode/Genericode04CodeListMarshallerTest.java) is available.

[Example code for reading GeneriCode v1.0 CodeList files](https://github.com/phax/ph-genericode/blob/master/src/test/java/com/helger/genericode/Genericode10CodeListMarshallerTest.java) is available.

[Example code for reading CVA files](https://github.com/phax/ph-genericode/blob/master/src/test/java/com/helger/cva/CVA10MarshallerTest.java) is available.

---

My personal [Coding Styleguide](https://github.com/phax/meta/blob/master/CodeingStyleguide.md) |
On Twitter: <a href="https://twitter.com/philiphelger">@philiphelger</a>
