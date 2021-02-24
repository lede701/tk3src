You'll also need to import the cert into your Trusted Root Certificates. To do this, click the cert error at top in Chrome then:

* Click certificate (invalid)
* Click the Details tab
* Click Copy to File...
* next next finish and export it somewhere.
* start-> run-> inetcpl.cpl
* click Content tab
* click Certificates
* click Trusted Root Certication Authorities tab
* Click Import button
* Import the cert
* Re-run ng serve --ssl

Be aware, the cert only lasts one month. At the end of that month you'll struggle to find a solution but I've already been through this and here is the fix
https://stackoverflow.com/a/63814027/4055033