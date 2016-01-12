/*
  Cmd.h - Library for command line mode for Arduino.
  Copyright (c) 2009 Yuriy Shcherbakov.  All right reserved.

  This library is free software; you can redistribute it and/or
  modify it under the terms of the GNU Lesser General Public
  License as published by the Free Software Foundation; either
  version 2.1 of the License, or (at your option) any later version.

  This library is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
  Lesser General Public License for more details.

  You should have received a copy of the GNU Lesser General Public
  License along with this library; if not, write to the Free Software
  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

#include "WProgram.h"
#include "Cmd.h"

Cmd::Cmd(void (*print)(char[]))
{
	_print = print;
	clear();
}

void Cmd::clear()
{
  _commandBufferLength = 0;
  _commandBuffer[0] = '\0';
  _commandCount = 0;
  for(int i = 0; i < commandMaxCount; i++)
    _commands[i] = 0;
}

boolean Cmd::isAvailable()
{
	return _commandCount > 0;
}
void Cmd::addChar(char c)
{
  if ((c == ' ') || (c == ';') || (c == '\n'))
    addWord((c == ';') || (c == '\n'));
  else
  {  
	if (_commandBufferLength < (commandTextMaxLen - 1))
    {
		if ((c >= 0x21) && (c <= 0xFF)) {
			_commandBuffer[_commandBufferLength++] = c;
			_commandBuffer[_commandBufferLength] = '\0';
		}
    }
    else
    {
      _print("TEXT IS TOO LONG\r\n");
	  clear();
    }
  }
}

void Cmd::addWord(boolean endOfCommand)
{
	if (_commandBufferLength == 0)
	{
		if (endOfCommand)
			_print("OK\r\n");
		return;
	}
    
	int keywordIndex = -1;

	for(int i = 0; i < _commandBufferLength; i++)
		if((_commandBuffer[i] >= 'a') && (_commandBuffer[i] <= 'z'))
			_commandBuffer[i] = _commandBuffer[i] - 32;

	int i = 0;
	char _keywordBuffer[keywordMaxLen];
  
	while(true)
	{
		memcpy_P(_keywordBuffer, keywords[i], keywordMaxLen);

		if (_keywordBuffer[0] == '\0')
			break;

		if (strcmp(_commandBuffer, _keywordBuffer) == 0)
		{
			keywordIndex = i;
			break;
		}
		i++;
	}

	if (keywordIndex >= 0)
		addKeyword(keywordIndex+1, endOfCommand);    
	else
	{
		_print("\r\n'");
		_print(_commandBuffer);
		_print("' IS UNKNOWN KEYWORD\r\n");
		clear();  
	}  
    _commandBufferLength = 0;
    _commandBuffer[0] = '\0';
}

void Cmd::addKeyword(int kw, boolean endOfCommand)
{
  _commands[_commandCount++] = kw;

  int keyword;

  if (!endOfCommand)
  {
		int i = 0;
		while (true) {
			keyword = pgm_read_byte(processNextKeyword + i);

			if (keyword == 0)
				break;
			if (kw == keyword)
			{
				return;
			}
			i++;
		}
  }
  addCommand();
  clear();  
}

boolean Cmd::isCommand(const prog_uchar cmd[])
{
	int keyword;

	int i=0;
	while (i < _commandCount) {
		keyword = pgm_read_byte(cmd + i);

		if ((keyword == 0) || (keyword != _commands[i]))
			return false;
		i++;
	}
	return pgm_read_byte(cmd + i) == 0;
}

void Cmd::addCommand()
{ 
  for(int i=0; i<mapCommandsSize; i++) 
  {
    if (isCommand(mapCommands[i]))
	{
		mapCommandProcs[i]();
		_print("OK\r\n");
		return;
	}
  }
  _print("\r\nUNKNOWN COMMAND\r\n");
}

