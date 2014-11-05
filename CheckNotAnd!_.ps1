cls
$a = 0;
$b = 1;
$c = 2;

if ($a) { "a" }

if (-not $a) { "-not a" }

if (!$a) { "!a" }

if (-not $a -and 1) { "-not a -and 1" }

if (!$a -and 1) { "!a -and 1" }

if (-not $a -or 1) { "-not a -or 1" }

if (!$a -or 1) { "!a -or 1" }

if ($b) { "b" }

if (-not $b) { "-not b" }

if (!$b) { "!b" }

if (-not $b -and 1) { "-not b -and 1" }

if (!$b -and 1) { "!b -and 1" }

if (-not $b -or 1) { "-not b -or 1" }

if (!$b -or 1) { "!b -or 1" }

if ($c) { "c" }

if (-not $c) { "-not c" }

if (!$c) { "!c" }

if (-not $c -and 1) { "-not c -and 1" }

if (!$c -and 1) { "!c -and 1" }

if (-not $c -or 1) { "-not c -or 1" }

if (!$c -or 1) { "!c -or 1" }