C1 -> S :
register Sepahan
formation R. Ahmadi:-6.500000:0.000000,E. Hajisafi:-2.000000:1.000000,M. Karimi:-5.000000:-2.000000,M. Navidkia:-5.000000:2.000000,H. Aghili:-2.000000:-1.000000

C2 -> S:
register Sepahan
formation R. Ahmadi:-6.500000:0.000000,E. Hajisafi:-2.000000:1.000000,M. Karimi:-5.000000:-2.000000,M. Navidkia:-5.000000:2.000000,H. Aghili:-2.000000:-1.000000
_________________________

S -> C1 :
-6.5:0,-2:1,-5:-2,-5:2,-2:-0.9999999
6.5:0,2:-0.9999999,5:2,5:-2,2:1
0:0
0,0,1

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-6.499999:0,-2:0.9999999,-5:-2,-5:2,-2:-1
6.5:0,2:-1,5:2,5:-2,2:0.9999999
0:0
0,0,2

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
-6.5:0,-2:1,-5:-2,-5:2,-2:-0.9999999
6.499999:0,2:-0.9999999,5:2,5:-2,2:1
0:0
0,0,3

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-6.5:0,-2:0.9999999,-5:-2,-5:2,-2:-1
6.5:0,2:-1,5:2,5:-2,2:0.9999999
0:0
0,0,4

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
-6.499999:0,-2:1,-5:-2,-5:2,-2:-0.9999999
6.5:0,2:-0.9999999,5:2,5:-2,2:1
0:0
0,0,5

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-6.5:0,-2:0.9999999,-5:-2,-5:2,-2:-1
6.499999:0,2:-1,5:2,5:-2,2:0.9999999
0:0
0,0,6

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
-6.5:0,-2:1,-5:-2,-5:2,-2:-0.9999999
6.5:0,2:-0.9999999,5:2,5:-2,2:1
0:0
0,0,7

C1 -> S :
0,0.0,100
_________________________

S -> C2 :
-6.5:0,-2:0.9999999,-5:-2,-5:2,-2:-1
-0.6639344:0.003230989,1.155087:-2.530058,5:2,5:-2,1.141714:2.552578
-5.205775:-0.02336365
0,0,8

C2 -> S :
1,333.43495111475323,100
_________________________

S -> C1 :
-5.884872:3.101484,-1.155048:2.530128,-5:-2,-5.445536:0.9257004,-1.141714:-2.552578
6.5:0,0.583546:-1.587318,5:2,5:-2,2:1
5.205775:0.02336365
0,0,9

C1 -> S :
1,333.434948822922,100
_________________________

S -> C2 :
-6.649459:-0.08600116,-0.583546:1.587318,-5:-2,-5.104733:3.026085,-5.773038:1.108513
5.884872:-3.101484,-0.9676068:-1.186565,5:2,5.445536:-0.9257004,1.141714:2.552578
-5.110322:-1.0034
0,0,10

C2 -> S :
2,21.80140948635181,100
_________________________

S -> C1 :
-5.884872:3.101484,-3.791907:1.486229,-5:-2,-5.445536:0.9257004,-1.141714:-2.552578
6.649459:0.08600116,0.1298571:-2.321715,1.39752:-0.9470758,5.104733:-3.026085,5.773038:-1.108513
5.11022:1.003504
0,0,11

C1 -> S :
0,0.0,100
_________________________

S -> C2 :
-6.649459:-0.08600116,-0.1298571:2.321715,-1.39752:0.9470758,-5.104733:3.026085,-5.773038:1.108513
-3.55747:-3.101491,3.791907:-1.486229,5:2,5.445536:-0.9257004,1.141714:2.552578
-5.11022:-1.003504
0,0,12

C2 -> S :
4,26.56505117707799,100
_________________________

S -> C1 :
3.55747:3.101491,-3.791907:1.486229,-5:-2,-5.445536:0.9257004,-1.336682:-2.431288
6.649459:0.08600116,-2.055257:-0.130505,1.39752:-0.9470758,5.104742:-3.026166,-0.3309322:-3.178237
5.11022:1.003504
0,0,13

C1 -> S :
2,21.80140948635181,100
_________________________

S -> C2 :
-6.649459:-0.08600116,-1.581611:-3.258643,-1.39752:0.9470758,-5.104742:3.026166,-0.5682535:2.852797
-3.55747:-3.101491,3.791907:-1.486229,0.7453972:1.142629,5.445536:-0.9257004,1.314173:2.817331
-5.11022:-1.003504
0,0,14

C2 -> S :
1,197.70438338558182,100
_________________________

S -> C1 :
1.589118:0.8923222,-3.791907:1.486229,-0.7453972:-1.142629,-5.445536:0.9257004,-1.314173:-2.817331
6.649459:0.08600116,2.503239:3.090567,1.39752:-0.9470758,5.104742:-3.026166,0.5682535:-2.852797
5.11022:1.003504
0,0,15

C1 -> S :
2,11.21386034422558,100
_________________________

S -> C2 :
-5.937055:-1.216788,-2.503239:-3.090567,-6.575214:1.430375,-5.104742:3.026166,-0.5682535:2.852797
-1.589037:-0.8923,3.791907:-1.486229,-0.3951726:0.04168129,5.445536:-0.9257004,1.314173:2.817331
-5.11022:-1.003504
0,0,16

C2 -> S :
0,329.2030475553725,100
_________________________

S -> C2 :
-6.5:0,-2:0.9999999,-5:-2,-5:2,-2:-1
6.5:0,2:-1,5:2,5:-2,2:0.9999999
0:0
0,1,17

C2 -> S :
4,287.42351354765583,100
_________________________

S -> C1 :
-6.5:0,-2:1,-5:-2,-5:2,-2:-0.9999999
6.5:0,2:-0.9999999,5:2,5:-2,-0.3102022:-2.125364
-4.113274:1.772749
1,0,18

C1 -> S :
0,349.19721434440527,100
_________________________

S -> C2 :
-6.5:0,-2:0.9999999,-5:-2,-5:2,-2.620225:2.484654
2.864854:0.3509141,2:-1,5:2,5:-2,-0.7015046:0.1866734
4.113274:-1.772749
0,1,19

C2 -> S :
2,207.71655598785716,100
_________________________

S -> C1 :
-2.864854:-0.3509141,-2:1,-5:-2,-5:2,0.7015681:-0.1866295
6.5:0,2:-0.9999999,-0.1587289:0.6119873,5:-2,2.620225:-2.484654
-4.113274:1.772749
1,0,20

C1 -> S :
0,306.50566936862475,100
_________________________

S -> C2 :
-6.5:0,-3.93847:-0.08449382,0.64898:-1.316326,-5:2,-2.620225:2.484654
-1.039727:1.161819,2:-1,5:2,5:-2,-0.896217:-0.2966849
4.113274:-1.772749
0,1,21

C2 -> S :
2,301.0444647614959,100
_________________________

S -> C1 :
1.039727:-1.161819,-2:1,-5.742528:-3.337756,-5:2,0.896217:0.2966849
6.5:0,3.93847:0.08449382,-4.768007:-0.9933906,5:-2,2.620225:-2.484654
-4.113318:1.772847
1,0,22

C1 -> S :
3,0.4223039246081415,100
_________________________

S -> C2 :
-6.5:0,-3.93847:-0.08449382,4.768007:0.9933906,-5:2,-2.620225:2.484654
-1.0398:1.161797,-0.0476027:0.5014923,5.742528:3.337756,0.7615761:-3.017919,-1.949067:-0.2409839
1.41273:-0.7463591
0,1,23

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
1.0398:-1.161797,0.0476027:-0.5014923,-5.742528:-3.337756,-0.7615761:3.017919,1.949067:0.2409839
6.5:0,3.93847:0.08449382,-4.768007:-0.9933906,5:-2,2.620225:-2.484654
-1.41273:0.7463591
1,0,24

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-6.5:0,-3.93847:-0.08449382,4.768007:0.9933906,-5:2,-2.620225:2.484654
-1.0398:1.161797,-0.0476027:0.5014923,5.742528:3.337756,0.7615761:-3.017919,-1.949067:-0.2409839
1.41273:-0.7463591
0,1,25

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
1.0398:-1.161797,0.0476027:-0.5014923,-5.742528:-3.337756,-0.7615761:3.017919,1.949067:0.2409839
6.5:0,3.93847:0.08449382,-4.768007:-0.9933906,5:-2,2.620225:-2.484654
-1.41273:0.7463591
1,0,26

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-6.5:0,-3.93847:-0.08449382,4.768007:0.9933906,-5:2,-2.620225:2.484654
-1.0398:1.161797,-0.0476027:0.5014923,5.742528:3.337756,0.7615761:-3.017919,-1.949067:-0.2409839
1.41273:-0.7463591
0,1,27

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
1.0398:-1.161797,0.0476027:-0.5014923,-5.742528:-3.337756,-0.7615761:3.017919,1.949067:0.2409839
6.5:0,3.93847:0.08449382,-4.768007:-0.9933906,5:-2,2.620225:-2.484654
-1.41273:0.7463591
1,0,28

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-6.5:0,-3.93847:-0.08449382,4.768007:0.9933906,-5:2,-2.620225:2.484654
-1.0398:1.161797,-0.0476027:0.5014923,5.742528:3.337756,0.7615761:-3.017919,-1.949067:-0.2409839
1.41273:-0.7463591
0,1,29

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
1.0398:-1.161797,0.0476027:-0.5014923,-5.742528:-3.337756,-0.7615761:3.017919,1.949067:0.2409839
6.5:0,3.93847:0.08449382,-4.768007:-0.9933906,5:-2,2.620225:-2.484654
-1.41273:0.7463591
1,0,30

C1 -> S :
0,36.6032466040576,100
_________________________

S -> C2 :
-6.667738:0.2823074,-3.938537:-0.08453166,4.768007:0.9933906,-5.280405:2.117243,-2.620286:2.484608
-4.096997:1.500937,-0.0476027:0.5014923,5.742528:3.337756,0.7615761:-3.017919,-6.078899:-0.9341956
1.41273:-0.7463591
0,1,31

C2 -> S :
3,338.1985905136482,100
_________________________

S -> C1 :
-0.3611049:2.073076,-3.09038:-1.235747,-5.742528:-3.337756,-1.346183:2.80167,6.078899:0.9341956
6.667738:-0.2823074,3.938537:0.08453166,-4.768007:-0.9933906,4.710258:-2.499847,2.620286:-2.484608
-1.41273:0.7463591
1,0,32

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-6.667738:0.2823074,-3.938537:-0.08453166,4.768007:0.9933906,-4.710258:2.499847,-2.620286:2.484608
0.3611049:-2.073076,3.09038:1.235747,5.742528:3.337756,1.346183:-2.80167,-6.078899:-0.9341956
1.41273:-0.7463591
0,1,33

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
-0.3612362:2.073012,-3.09038:-1.235747,-5.742528:-3.337756,-1.346183:2.80167,6.078899:0.9341956
6.667738:-0.2823074,3.938537:0.08453166,-4.768007:-0.9933906,4.710258:-2.499847,2.620286:-2.484608
-1.41273:0.7463591
1,0,34

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-6.667778:0.2823741,-3.938537:-0.08453166,4.768007:0.9933906,-4.710258:2.499847,-2.620286:2.484608
0.3612362:-2.073012,3.09038:1.235747,5.742528:3.337756,1.346183:-2.80167,-6.078899:-0.9341956
1.41273:-0.7463591
0,1,35

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
-0.3612362:2.073012,-3.09038:-1.235747,-5.742528:-3.337756,-1.346183:2.80167,6.078899:0.9341956
6.667778:-0.2823741,3.938537:0.08453166,-4.768007:-0.9933906,4.710258:-2.499847,2.620286:-2.484608
-1.41273:0.7463591
1,0,36

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-6.667778:0.2823741,-3.938537:-0.08453166,4.768007:0.9933906,-4.710258:2.499847,-2.620286:2.484608
0.3612362:-2.073012,3.09038:1.235747,5.742528:3.337756,1.346183:-2.80167,-6.078899:-0.9341956
1.41273:-0.7463591
0,1,37

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
-0.3612362:2.073012,-3.09038:-1.235747,-5.742528:-3.337756,-1.346183:2.80167,6.078899:0.9341956
6.667778:-0.2823741,3.938537:0.08453166,-4.768007:-0.9933906,4.710258:-2.499847,2.620286:-2.484608
-1.41273:0.7463591
1,0,38

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-6.667778:0.2823741,-3.938537:-0.08453166,4.768007:0.9933906,-4.710258:2.499847,-2.620286:2.484608
0.3612362:-2.073012,3.09038:1.235747,5.742528:3.337756,1.346183:-2.80167,-6.078899:-0.9341956
1.41273:-0.7463591
0,1,39

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
-0.3612362:2.073012,-3.09038:-1.235747,-5.742528:-3.337756,-1.346183:2.80167,6.078899:0.9341956
6.667778:-0.2823741,3.938537:0.08453166,-4.768007:-0.9933906,4.710258:-2.499847,2.620286:-2.484608
-1.41273:0.7463591
1,0,40

C1 -> S :
2,76.7735780844926,100
_________________________

S -> C2 :
-6.667778:0.2823741,-3.938537:-0.08453166,2.077926:-1.150649,-4.710258:2.499847,-2.620286:2.484608
0.2249182:-2.009282,3.090454:1.235764,6.552481:0.9670354,1.07986:-2.815978,-6.078899:-0.9341956
1.412832:-0.7463334
0,1,41

C2 -> S :
2,1.4284466154935072,100
_________________________

S -> C1 :
-0.2249182:2.009282,-3.090454:-1.235764,-6.158946:-2.494241,-1.07986:2.815978,6.078899:0.9341956
6.667778:-0.2823741,3.938537:0.08453166,-5.714707:-0.02463555,4.710258:-2.499847,2.620286:-2.484608
-1.412832:0.7463334
1,0,42

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-6.667778:0.2823741,-3.938537:-0.08453166,5.714707:0.02463555,-4.710258:2.499847,-2.620286:2.484608
0.2249182:-2.009282,3.090454:1.235764,6.158946:2.494241,1.07986:-2.815978,-6.078899:-0.9341956
1.412832:-0.7463334
0,1,43

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
-0.2248499:2.00925,-3.090454:-1.235764,-6.158946:-2.494241,-1.07986:2.815978,6.078899:0.9341956
6.667778:-0.2823741,3.938537:0.08453166,-5.714707:-0.02463555,4.710258:-2.499847,2.620286:-2.484608
-1.412832:0.7463334
1,0,44

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-6.667778:0.2823741,-3.938537:-0.08453166,5.714707:0.02463555,-4.710258:2.499847,-2.620286:2.484608
0.2248499:-2.00925,3.090454:1.235764,6.158946:2.494241,1.07986:-2.815978,-6.078899:-0.9341956
1.412832:-0.7463334
0,1,45

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
-0.2248499:2.00925,-3.090454:-1.235764,-6.158946:-2.494241,-1.07986:2.815978,6.078899:0.9341956
6.667778:-0.2823741,3.938537:0.08453166,-5.714707:-0.02463555,4.710258:-2.499847,2.620286:-2.484608
-1.412832:0.7463334
1,0,46

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-6.667778:0.2823741,-3.938537:-0.08453166,5.714707:0.02463555,-4.710258:2.499847,-2.620286:2.484608
0.2248499:-2.00925,3.090454:1.235764,6.158946:2.494241,1.07986:-2.815978,-6.078899:-0.9341956
1.412832:-0.7463334
0,1,47

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
-0.2248499:2.00925,-3.090454:-1.235764,-6.158946:-2.494241,-1.07986:2.815978,6.078899:0.9341956
6.667778:-0.2823741,3.938537:0.08453166,-5.714707:-0.02463555,4.710258:-2.499847,2.620286:-2.484608
-1.412832:0.7463334
1,0,48

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-6.667778:0.2823741,-3.938537:-0.08453166,5.714707:0.02463555,-4.710258:2.499847,-2.620286:2.484608
0.2248499:-2.00925,3.090454:1.235764,6.158946:2.494241,1.07986:-2.815978,-6.078899:-0.9341956
1.412832:-0.7463334
0,1,49

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
-0.2248499:2.00925,-3.090454:-1.235764,-6.158946:-2.494241,-1.07986:2.815978,6.078899:0.9341956
6.667778:-0.2823741,3.938537:0.08453166,-5.714707:-0.02463555,4.710258:-2.499847,2.620286:-2.484608
-1.412832:0.7463334
1,0,50

C1 -> S :
3,345.6308148463049,100
_________________________

S -> C2 :
-6.783407:0.446824,-5.769412:1.024838,5.714707:0.02463555,-4.710258:2.499847,-2.620286:2.484608
-2.848903:0.8432959,3.090454:1.235764,6.158946:2.494241,-1.030142:-2.384367,-6.079003:-0.9342462
1.412832:-0.7463334
0,1,51

C2 -> S :
0,350.5173514466186,100
_________________________

S -> C1 :
2.551159:-0.3945203,-3.090454:-1.235764,-6.158946:-2.494241,1.030142:2.384367,4.305305:2.318044
5.498295:-0.2653208,3.301505:-1.768916,-5.714707:-0.02463555,4.710221:-2.499915,-0.8489339:-2.497867
-1.412832:0.7463334
1,0,52

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-5.498295:0.2653208,-3.301505:1.768916,5.714707:0.02463555,-4.710221:2.499915,0.8489339:2.497867
-2.551159:0.3945203,3.090454:1.235764,6.158946:2.494241,-1.030142:-2.384367,-4.305305:-2.318044
1.412832:-0.7463334
0,1,53

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
2.551117:-0.3944567,-3.090454:-1.235764,-6.158946:-2.494241,1.030142:2.384367,4.305305:2.318044
5.498295:-0.2653208,3.301505:-1.768916,-5.714707:-0.02463555,4.710221:-2.499915,-0.8489339:-2.497867
-1.412832:0.7463334
1,0,54

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-5.498222:0.2653387,-3.301505:1.768916,5.714707:0.02463555,-4.710221:2.499915,0.8489339:2.497867
-2.551117:0.3944567,3.090454:1.235764,6.158946:2.494241,-1.030142:-2.384367,-4.305305:-2.318044
1.412832:-0.7463334
0,1,55

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
2.551117:-0.3944567,-3.090454:-1.235764,-6.158946:-2.494241,1.030142:2.384367,4.305305:2.318044
5.498222:-0.2653387,3.301505:-1.768916,-5.714707:-0.02463555,4.710221:-2.499915,-0.8489339:-2.497867
-1.412832:0.7463334
1,0,56

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-5.498222:0.2653387,-3.301505:1.768916,5.714707:0.02463555,-4.710221:2.499915,0.8489339:2.497867
-2.551117:0.3944567,3.090454:1.235764,6.158946:2.494241,-1.030142:-2.384367,-4.305305:-2.318044
1.412832:-0.7463334
0,1,57

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
2.551117:-0.3944567,-3.090454:-1.235764,-6.158946:-2.494241,1.030142:2.384367,4.305305:2.318044
5.498222:-0.2653387,3.301505:-1.768916,-5.714707:-0.02463555,4.710221:-2.499915,-0.8489339:-2.497867
-1.412832:0.7463334
1,0,58

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-5.498222:0.2653387,-3.301505:1.768916,5.714707:0.02463555,-4.710221:2.499915,0.8489339:2.497867
-2.551117:0.3944567,3.090454:1.235764,6.158946:2.494241,-1.030142:-2.384367,-4.305305:-2.318044
1.412832:-0.7463334
0,1,59

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
2.551117:-0.3944567,-3.090454:-1.235764,-6.158946:-2.494241,1.030142:2.384367,4.305305:2.318044
5.498222:-0.2653387,3.301505:-1.768916,-5.714707:-0.02463555,4.710221:-2.499915,-0.8489339:-2.497867
-1.412832:0.7463334
1,0,60

C1 -> S :
3,254.00478778257252,100
_________________________

S -> C2 :
-5.498222:0.2653387,-3.301505:1.768916,5.714707:0.02463555,-4.710221:2.499915,2.015335:1.476347
-2.551117:0.3944567,4.196517:-0.01965833,6.158946:2.494241,-0.6980712:2.539211,-4.305305:-2.318044
1.412832:-0.7463334
0,1,61

C2 -> S :
1,352.94915819999625,100
_________________________

S -> C1 :
2.551117:-0.3944567,-4.196517:0.01965833,-6.39832:-2.955471,0.6981271:-2.539263,4.305305:2.318044
5.498222:-0.2653387,-1.392923:-0.09735972,-5.714707:-0.02463555,4.710221:-2.499915,-5.868032:-1.374399
-1.412832:0.7463334
1,0,62

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-5.498222:0.2653387,1.392923:0.09735972,5.714707:0.02463555,-4.710221:2.499915,5.868032:1.374399
-2.551117:0.3944567,4.196517:-0.01965833,6.39832:2.955471,-0.6981271:2.539263,-4.305305:-2.318044
1.412832:-0.7463334
0,1,63

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
2.551117:-0.3944567,-4.196517:0.01965833,-6.39832:-2.955471,0.6981271:-2.539263,4.305305:2.318044
5.498222:-0.2653387,-1.392923:-0.09735972,-5.714707:-0.02463555,4.710221:-2.499915,-5.868032:-1.374399
-1.412832:0.7463334
1,0,64

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-5.498222:0.2653387,1.392923:0.09735972,5.714707:0.02463555,-4.710221:2.499915,5.868032:1.374399
-2.551117:0.3944567,4.196517:-0.01965833,6.39832:2.955471,-0.6981271:2.539263,-4.305305:-2.318044
1.412832:-0.7463334
0,1,65

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
2.551117:-0.3944567,-4.196517:0.01965833,-6.39832:-2.955471,0.6981271:-2.539263,4.305305:2.318044
5.498222:-0.2653387,-1.392923:-0.09735972,-5.714707:-0.02463555,4.710221:-2.499915,-5.868032:-1.374399
-1.412832:0.7463334
1,0,66

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-5.498222:0.2653387,1.392923:0.09735972,5.714707:0.02463555,-4.710221:2.499915,5.868032:1.374399
-2.551117:0.3944567,4.196517:-0.01965833,6.39832:2.955471,-0.6981271:2.539263,-4.305305:-2.318044
1.412832:-0.7463334
0,1,67

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
2.551117:-0.3944567,-4.196517:0.01965833,-6.39832:-2.955471,0.6981271:-2.539263,4.305305:2.318044
5.498222:-0.2653387,-1.392923:-0.09735972,-5.714707:-0.02463555,4.710221:-2.499915,-5.868032:-1.374399
-1.412832:0.7463334
1,0,68

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-5.498222:0.2653387,1.392923:0.09735972,5.714707:0.02463555,-4.710221:2.499915,5.868032:1.374399
-2.551117:0.3944567,4.196517:-0.01965833,6.39832:2.955471,-0.6981271:2.539263,-4.305305:-2.318044
1.412832:-0.7463334
0,1,69

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
2.551117:-0.3944567,-4.196517:0.01965833,-6.39832:-2.955471,0.6981271:-2.539263,4.305305:2.318044
5.498222:-0.2653387,-1.392923:-0.09735972,-5.714707:-0.02463555,4.710221:-2.499915,-5.868032:-1.374399
-1.412832:0.7463334
1,0,70

C1 -> S :
0,142.11580678084047,100
_________________________

S -> C2 :
-5.498222:0.2653387,1.392923:0.09735972,5.714707:0.02463555,-4.710221:2.499915,5.868032:1.374399
4.889658:-1.479838,4.196517:-0.01965833,6.39832:2.955471,-0.6981271:2.539263,-4.305305:-2.318044
1.412832:-0.7463334
0,1,71

C2 -> S :
2,207.4072583767449,100
_________________________

S -> C1 :
-4.144247:2.290386,-2.117078:1.096804,-6.39832:-2.955471,0.6981271:-2.539263,4.305305:2.318044
5.498222:-0.2653387,3.659931:-0.5418837,-5.178432:0.4978578,4.710221:-2.499915,-5.868032:-1.374399
-1.412832:0.7463334
1,0,72

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-5.498222:0.2653387,-3.659931:0.5418837,5.178432:-0.4978578,-4.710221:2.499915,5.868032:1.374399
4.144247:-2.290386,2.117078:-1.096804,6.39832:2.955471,-0.6981271:2.539263,-4.305305:-2.318044
1.412832:-0.7463334
0,1,73

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
-4.14423:2.290312,-2.117078:1.096804,-6.39832:-2.955471,0.6981271:-2.539263,4.305305:2.318044
5.498222:-0.2653387,3.659931:-0.5418837,-5.178432:0.4978578,4.710221:-2.499915,-5.868032:-1.374399
-1.412832:0.7463334
1,0,74

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-5.498222:0.2653387,-3.659931:0.5418837,5.178432:-0.4978578,-4.710221:2.499915,5.868032:1.374399
4.14423:-2.290312,2.117078:-1.096804,6.39832:2.955471,-0.6981271:2.539263,-4.305305:-2.318044
1.412832:-0.7463334
0,1,75

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
-4.14423:2.290312,-2.117078:1.096804,-6.39832:-2.955471,0.6981271:-2.539263,4.305305:2.318044
5.498222:-0.2653387,3.659931:-0.5418837,-5.178432:0.4978578,4.710221:-2.499915,-5.868032:-1.374399
-1.412832:0.7463334
1,0,76

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C2 :
-5.498222:0.2653387,-3.659931:0.5418837,5.178432:-0.4978578,-4.710221:2.499915,5.868032:1.374399
4.14423:-2.290312,2.117078:-1.096804,6.39832:2.955471,-0.6981271:2.539263,-4.305305:-2.318044
1.412832:-0.7463334
0,1,77

EXCEPTION team2: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
_________________________

S -> C1 :
-4.14423:2.290312,-2.117078:1.096804,-6.39832:-2.955471,0.6981271:-2.539263,4.305305:2.318044
5.498222:-0.2653387,3.659931:-0.5418837,-5.178432:0.4978578,4.710221:-2.499915,-5.868032:-1.374399
-1.412832:0.7463334
1,0,78

EXCEPTION team1: System.IO.IOException: Read failure ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.

  at System.Net.Sockets.Socket.Receive (System.Byte[] buffer, Int32 offset, Int32 size, SocketFlags flags) [0x00000] in <filename unknown>:0 
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  --- End of inner exception stack trace ---
  at System.Net.Sockets.NetworkStream.Read (System.Byte[] buffer, Int32 offset, Int32 size) [0x00000] in <filename unknown>:0 
  at System.IO.StreamReader.ReadBuffer () [0x00012] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:338 
  at System.IO.StreamReader.ReadLine () [0x0001b] in /Users/builduser/buildslave/mono/build/mcs/class/corlib/System.IO/StreamReader.cs:464 
  at GameManager.receive_data_from_client (System.IO.StreamReader sr, System.Int32& r_id, System.Int32& r_angle, System.Int32& r_power) [0x00003] in D:\University\UIACM\UIAI2018\UIAI2018_Server\Assets\Scripts\GameManager.cs:792 
