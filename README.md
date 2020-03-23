# MISS1-EBS
This project is written using C# programming language (.NET Framework 4.7.2), with help from Visual Studio Comunity Edition and earned knowledge along the last 8 years.
## Installing
This project is compiled under .NET Framework 4.7.2 and is delivered as an executable, therefore you need an OS version of Microsoft Windows Windows 7 SP1 (or later) or Windows Server 2008 R2 (or later) to  run this app.
## Running the app
Run the executable located at `\bin\Debug\Generate_Publishers-Subscribers.exe`
## Configuration
You must make sure that before running the app you have 2 XML files to specify the inputs for this application. They must be located at the root path of the project (`\`). They are named `publications-config.xml` and `subscriber-config.xml`.
 `subscriber-config.xml` has the following structure:
 ```xml
 <?xml version="1.0" encoding="utf-8" ?>
<subscribers>
  <count>20</count>  <!--number of subscriptions to generate-->
  <companies> <!--markdown for company field-->
    <display-percentage>0,3</display-percentage> <!--the percentage of companies field to appear in the output file (can be 0)-->
    <equal-operator-frequency>1</equal-operator-frequency> <!--the minimum percentage of companies field having '==' operator (can be 0)-->
    <company>Google</company> <!--values for company field-->
    <company>Microsoft</company>
    <company>Yahoo</company>
    <company>Amazon</company>
  </companies>
  <dates>
    <display-percentage>0,5</display-percentage> <!--same as above-->
    <date>02.02.2022</date> <!--values for date field-->
    <date>23.03.2020</date>
  </dates>
  <values>
    <display-percentage>0,8</display-percentage>
    <min>50,0</min> <!--minimum value for field 'value'-->
    <max>100,0</max> <!--maximum value for field 'value'-->
  </values>
  <drops>
    <display-percentage>0,45</display-percentage>
    <min>10,0</min>
    <max>15,0</max>
  </drops>
  <variations>
    <display-percentage>0,76</display-percentage>
    <min>0,4</min>
    <max>0,9</max>
  </variations>
</subscribers>
```
`publications-config.xml` has the following structure:
```xml
<?xml version="1.0" encoding="utf-8" ?> 
<publications>
  <count>10</count> <!--number of publications to generate-->
  <companies> <!--markdown for company field-->
    <company>Google</company> <!--values for company field-->
    <company>Microsoft</company>
    <company>Yahoo</company>
    <company>Amazon</company>
  </companies>
  <dates>
    <date>02.02.2022</date>
    <date>23.03.2020</date>
  </dates>
  <value>
    <min>50,0</min>
    <max>100,0</max>
  </value>
  <drop> 
    <min>10,0</min> <!--minimum value for field 'drop'-->
    <max>15,0</max> <!--maximum value for field 'drop'-->
  </drop>
  <variation>
    <min>0,4</min>
    <max>0,9</max>
  </variation>
</publications>
```
## Output
Upon running the apps you will see the output files (`publications.txt`, `subscriptions.txt`) located at the same path with the executable (`\bin\Debug\publications.txt`, `\bin\Debug\subscriptions.txt`)
