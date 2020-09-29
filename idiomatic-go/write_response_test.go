package main

import (
	"bytes"
	"strings"
	"testing"
)

func TestWriteResponse(t *testing.T) {
	status := Status{Code: 555, Reason: "account not found."}
	headers := []Header{
		{"Content-Type", "application/json"},
	}
	body := strings.NewReader("this is a body")

	var buf bytes.Buffer
	err := WriteResponse(&buf, status, headers, body)

	var e bytes.Buffer
	e.WriteString("HTTP/1.1 555 account not found.\r\n")
	e.WriteString("Content-Type: application/json\r\n\r\n")
	e.WriteString("this is a body")

	if e.String() != buf.String() {
		t.Errorf("expected : \n%q\nbut got :\n%q\n", e.String(), buf.String())
	}

	if err != nil {
		t.Error("should not be an error but got :", err)
	}
}
