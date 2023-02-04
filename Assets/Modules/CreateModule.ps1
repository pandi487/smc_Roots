$UpperName = Read-Host -Prompt "Input Module Name"
$LowerName = $UpperName.ToLower()
mkdir "$UpperName"
mkdir "$UpperName/Runtime/"
mkdir "$UpperName/Examples/Test/Scenes"
mkdir "$UpperName/Examples/Test/Scripts"
"{
    `"name`": `"com.uleed.$LowerName`",
    `"version`": `"0.1.0`",
    `"displayName`": `"Uleed $UpperName module`",
    `"description`": `"`",
    `"unity`": `"2020.2`",
    `"type`": `"tool`",
    `"author`": {
      `"name`": `"Uleed`",
      `"email`": `"info@uleed.fr`"
    }
  }"
| Out-File "$UpperName/package.json" 
"Readme $UpperName" | Out-File "$UpperName/readme.md" 
"{
    `"name`": `"Unity.uleed.$LowerName`",
    `"rootNamespace`": `"`",
    `"references`": [
    ],
    `"includePlatforms`": [],
    `"excludePlatforms`": [],
    `"allowUnsafeCode`": false,
    `"overrideReferences`": false,
    `"precompiledReferences`": [],
    `"autoReferenced`": true,
    `"defineConstraints`": [],
    `"versionDefines`": [],
    `"noEngineReferences`": false
}"
| Out-File "$UpperName/Runtime/Unity.uleed.$LowerName.asmdef" 