package main

import (
	"github.com/gorilla/mux"
	"log"
	"net/http"
)

func main() {

	r := mux.NewRouter()
	r.HandleFunc("/pairs", CreateDevicesHandler).Methods(http.MethodPost)

	srv := http.Server{
		Handler: r,
		Addr:    "127.0.0.1:2009",
	}

	log.Println("staring..")
	log.Fatal(srv.ListenAndServe())
}

func CreateDevicesHandler(w http.ResponseWriter, r *http.Request) {

	w.Write([]byte(`{"status":"active"}`))
}
