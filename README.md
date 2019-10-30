# CryptoService

## Welcome
This code aims to create a way to easily secure passwords for your C# programs and to verify if the passwords match or not. This is a simple program, and was adapted from various readings on the internet in regards to how to implement this. 
## Usage
To use this, simply build the solution to generate the .dll and use that .dll as a refence in any project you need to secure passwords. 

* Generate Salt
* Compute Hash
* Verifiy Password

I made this for a console app that is using a txt file with the username and stored password and wanted to make the password secure so it was not in plaintext. Of course, in the real world, you would never create a system like this. This could be used for storing passwords to a database though, and then checking to see if said passwords match in a user auth system later on. 

You will store the hash, the salt, and thats it. No need to encrypt the salt. To decode, you will need the input password from a user, the stored hash of the password, and the stored salt. The verification will essentially hash the user supplied password using the stored salt and comparing the hash against the stored hash. If they are equal on every element, then they are the same password, and the user is authenticated. 

This is a work in progress as I am learning about cryptography and best practices. If something is not quite right here, feel free to shoot me a message at info@pbsteele.com Thanks and hopefully this is a little useful to someone!
