require 'albacore'

VERSION = "1.0.0"

task :default => [:build, :merge, :output, :package]

assemblyinfo :assemblyinfo do |asm|
	asm.version = VERSION
	asm.company_name = "Justin Soliz"
	asm.product_name = "Dwolla.net"
	asm.title = "Dwolla.net"
	asm.description = "A .net client api for http://dwolla.com"
	asm.copyright = "Copyright (C) Justin Soliz 2012"
	asm.output_file = "src/SharedAssemblyInfo.cs"
end

desc "Build"
msbuild :build => :assemblyinfo do |msb|
	msb.properties :configuration => :Release
	msb.targets :Clean, :Build
	msb.solution = "src/Dwolla.sln"
	puts 'Solution built'
end

desc "Merge"
exec :merge do |cmd|
	cmd.command = 'tools\ilmerge\ilmerge.exe'
	cmd.parameters ='/out:src\Dwolla\bin\release\Dwolla.dll /targetplatform:v4,"C:\Windows\Microsoft.NET\Framework\v4.0.30319" src\Dwolla\bin\release\Dwolla.dll src\Dwolla\bin\release\Newtonsoft.Json.dll /closed /internalize'
	puts 'Merging complete'
end

desc "Output"
output :output do |out|
	out.from '.'
	out.to 'build'
	out.file 'src\Dwolla\bin\release\Dwolla.dll', :as=>'Dwolla.dll'
	puts 'Output folder created'
end

desc "Package"
zip :package do |zip|
	zip.directories_to_zip "build"
	zip.output_file = "Dwolla #{VERSION}.zip"
	zip.output_path = File.join(File.dirname(__FILE__), 'build')
	puts 'Packing complete'
end