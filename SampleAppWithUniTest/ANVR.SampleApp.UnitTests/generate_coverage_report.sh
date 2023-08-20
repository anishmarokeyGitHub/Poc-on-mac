#!/bin/zsh

# Navigate to the root directory of your project
cd /Users/anishvarghese/Desktop/Dotnet/netcore-Poc-on-mac/SampleAppWithUniTest/ANVR.SampleApp.UnitTests/

# Directory path to the old coverage report
oldCoverageReportPath="TestResults"

# Delete the old coverage report directory if it exists
if [ -d "$oldCoverageReportPath" ]; then
    rm -r "$oldCoverageReportPath"
    echo "Old coverage report directory deleted."
fi

# Run dotnet test with code coverage collection
dotnet test --collect:"XPlat Code Coverage"

echo "What is guid generated in TestResults: "
read var_testtesult_guid 

# Relative path to the new coverage report XML file
coverageReportRelativePath="TestResults/${var_testtesult_guid}/coverage.cobertura.xml"

# Target directory for the coverage report
targetDir="coveragereport"

# Generate HTML report using reportgenerator
~/.dotnet/tools/reportgenerator -reports:"$coverageReportRelativePath" -targetdir:"$targetDir" -reporttypes:Html

echo "Code coverage report generated at $targetDir"

# Open the HTML report in the default web browser
open "$targetDir/index.html"
