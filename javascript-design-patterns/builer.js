var Event = (function() {
  function Event(name) {
    this.name = name;
  }
  return Event;
})();

var Prize = (function() {
  function Prize(name) {
    this.name = name;
  }
  return Prize;
})();

var Attendee = (function() {
  function Attendee(name) {
    this.name = name;
  }
  return Attendee;
})();

var Tournament = (function() {
  function Tournament() {
    this.events = [];
    this.attendees = [];
    this.prizes = [];
  }
  return Tournament;
})();

var LannisterTournamentBuilder = (function() {
  function LannisterTournamentBuilder() {}

  LannisterTournamentBuilder.prototype.build = function() {
    var tournament = new Tournament();
    tournament.events.push(new Event("Joust"));
    tournament.events.push(new Event("Melle"));
    tournament.attendees.push(new Attendee("Jamie"));
    tournament.prizes.push(new Prize("Gold"));
    tournament.prizes.push(new Prize("More Gold"));
    return tournament;
  };
  return LannisterTournamentBuilder;
})();

var BaratheonTournamentBuilder = (function() {
  function BaratheonTournamentBuilder() {}

  BaratheonTournamentBuilder.prototype.build = function() {
    var tournament = new Tournament();
    tournament.events.push(new Event("Joust"));
    tournament.events.push(new Event("Melle"));
    tournament.attendees.push(new Attendee("Stannis"));
    tournament.attendees.push(new Attendee("Robert"));
    return tournament;
  };
  return BaratheonTournamentBuilder;
})();

var TournamentBuilder = (function() {
  function TournamentBuilder() {}
  TournamentBuilder.prototype.build = function(builder) {
    return builder.build();
  };
  return TournamentBuilder;
})();

var tournament1 = new TournamentBuilder().build(
  new BaratheonTournamentBuilder()
);

var tournament2 = new TournamentBuilder().build(
  new LannisterTournamentBuilder()
);

console.log(JSON.stringify(tournament1, null, 2));
console.log(JSON.stringify(tournament2, null, 2));
