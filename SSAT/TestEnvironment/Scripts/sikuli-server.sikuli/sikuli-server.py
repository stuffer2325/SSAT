import time
import imp
import socket
import unitest
from unitest import *

TCP_IP = '127.0.0.1'
TCP_PORT = 8889
BUFFER_SIZE = 1024 
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.bind((TCP_IP, TCP_PORT))
s.listen(1) 
while True:
  conn, addr = s.accept()
  data = conn.recv(BUFFER_SIZE)
  data = data[0:data.index('*')]
  conn.close()
  if (data == "<stop>"):
    s.close()
    break
  try:
    imp.load_source("runtime",data)
  except:
    try:
      send("The current execution has been failed.")
    except:
      print "Error"