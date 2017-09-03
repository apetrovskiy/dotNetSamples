
SpecFlow+ Excel  (SpecFlow Plugin)
==================================

This SpecFlow plugin enables writing SpecFlow tests in Excel files. You can 
specify SpecFlow feature files in Excel or extend scenario outlines in normal 
feature files with further examples from Excel.

The package also contains a converter too that can be used to convert Excel 
files to Gherkin and vica versa.

Please check our website (http://www.specflow.org/plus/Excel) for an 
introduction and a getting started guide. 

Please also check the documentation pages at 
http://www.specflow.org/plus/documentation.

The feature files describing the possibilites with the plugin can be found in 
the 'docs' folder of this package.

Contact
^^^^^^^

Please send your feedback to info@specflowplus.com.

Licensing
^^^^^^^^^

The component can be purchased as part of 
SpecFlow+. See http://www.specflow.org/plus/ for details.

Evaluation: You can evaluate all features of SpecFlow+ Excel for free. 
In evaluation mode, an extra scenario is generated with title 
"SpecFlow+ Excel Evaluation Mode". Please purchase at 
http://www.specflow.org/plus/ to remove this limitation.
See http://www.specflow.org/plus/Evaluation for details.

Important notes
^^^^^^^^^^^^^^^

This package enables the build-time generation feature of SpecFlow by adding an 
MsBuild target to the project file. This ensures that the tests from the Excel 
files are re-generated when necessary.

How to add a new Excel feature file?
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

1. Create an Excel file with "*.feature.xlsx" suffix 
   (e.g. MyCalculation.feature.xlsx). 
2. Include the Excel file to the project.
3. Compile the project. This will generate the related code-behind file 
   (MyCalculation.feature.xlsx.cs) and the related feature file 
   (MyCalculation.feature.xlsx.feature). The feature file generation can be 
   switched off by specifying a "skip-feature-file" tag on the feature Excel.
4. Include the generated files to the project. 
5. Compile the project again: 
   You are ready to run your tests described in the Excel file!
6. Optionally you can mark the generated files as the dependent file of the 
   Excel file, so that it is displayed as a sub-item in Visual Studio.
7. Optionally you can ignore generated files from source control:
   *.feature.cs
   *.feature.xlsx.*

How to add a new Excel examples file?
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

1. Describe your scenario outline as Gherkin in a normal feature file.
2. Create an Excel file (e.g. CustomExamples.xlsx), with worksheet named as the 
   scenario outline. (You can use the same Excel file for multiple scenario 
   outlines.)
3. Add the desired examples data to the worksheet and save the Excel file.
4. Include the Excel file to the project.
5. Tag the "Examles" section of the scenario outline with
   @source:CustomExamples.xlsx. Optionally, you can also specify the sheet name 
   to be used: @source:CustomExamples.xlsx:Sheet1.
6. Compile the project: The examples from the Excel file will appear as new 
   tests!
