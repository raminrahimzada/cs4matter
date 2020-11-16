# cs4matter
C# File Indent Formatter cli application

## If you need only binaries, look [here](/Binaries/)


## Usage :
```cmd
cs4matter {input-file} [output-file]
```
If no output-file specified it will be equal to input-file

## To format all files in a directory :
```cmd
for /f %F in ('dir /s /b /a-d *.cs') do cs4matter "%F"

```
