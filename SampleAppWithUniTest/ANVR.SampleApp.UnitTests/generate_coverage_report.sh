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
# dotnet test --collect:"XPlat Code Coverage"
# echo "Attachments $Attachments"


# Run the test command and capture the output
output=$(dotnet test --collect:"XPlat Code Coverage" 2>&1)

# Extract the coverage report file path using grep and sed
coverage_path=$(echo "$output" | grep -o -m 1 '/[^[:space:]]*coverage\.cobertura\.xml' | sed -E 's|^[[:space:]]*||')

# Print the coverage report file path
if [ -n "$coverage_path" ]; then
  echo "Coverage report file path: $coverage_path"
else
  echo "Coverage report file path not found."
fi

# Target directory for the coverage report
targetDir="coveragereport"

# Generate HTML report using reportgenerator
~/.dotnet/tools/reportgenerator -reports:"$coverage_path" -targetdir:"$targetDir" -reporttypes:Html

echo "Code coverage report generated at $targetDir"

# Open the HTML report in the default web browser
open "$targetDir/index.html"
