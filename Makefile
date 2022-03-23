out:
	@dotnet bin/Debug/net6.0/AtCoderTemplate.dll	

test:
	@for i in 1 2 3 4 5; do\
		echo "$$i 回目のループを開始します。";\
		dotnet bin/Debug/net6.0/AtCoderTemplate.dll;\
		echo "$$i 回目のループを終了します。";\
	done

a:
	@dotnet build -p:StartupObject=AtCoderTemplate.ProgramA

ac:
	@sh copy.sh src/ProgramA.cs

b:
	@dotnet build -p:StartupObject=AtCoderTemplate.ProgramB

bc:
	@sh copy.sh src/ProgramB.cs

c:
	@dotnet build -p:StartupObject=AtCoderTemplate.ProgramC

cc:
	@sh copy.sh src/ProgramC.cs

d:
	@dotnet build -p:StartupObject=AtCoderTemplate.ProgramD

dc:
	@sh copy.sh src/ProgramD.cs

e:
	@dotnet build -p:StartupObject=AtCoderTemplate.ProgramE

ec:
	@sh copy.sh src/ProgramE.cs

f:
	@dotnet build -p:StartupObject=AtCoderTemplate.ProgramF

fc:
	@sh copy.sh src/ProgramF.cs

build:
	@dotnet build -p:StartupObject=AtCoderTemplate.Program

copy:
	@awk '$$1 !~ "using"{print}' src/library/*.cs | cat src/Program.cs - | pbcopy
