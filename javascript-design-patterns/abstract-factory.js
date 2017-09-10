var KingJoffery = (function() {
  function KingJoffery() {}
  KingJoffery.prototype.makeDecision = function() {
    console.log("KingJoffery: makeDecision");
  };
  return KingJoffery;
})();

var KingAerys = (function() {
  function KingAerys() {}
  KingAerys.prototype.makeDecision = function() {
    console.log("KingAerys: makeDecision");
  };
  return KingAerys;
})();

var LordTywin = (function() {
  function LordTywin() {}

  LordTywin.prototype.makeDecision = function() {
    console.log("LordTywin: makeDecision");
  };
  return LordTywin;
})();

var LordConnington = (function() {
  function LordConnington() {}

  LordConnington.prototype.makeDecision = function() {
    console.log("LordConnington: makeDecision");
  };
  return LordConnington;
})();

var LennisterFactory = (function() {
  function LennisterFactory() {}
  LennisterFactory.prototype.getKing = function() {
    return new KingJoffery();
  };

  LennisterFactory.prototype.getHandOfTheKing = function() {
    return new LordTywin();
  };
  return LennisterFactory;
})();

var TargaryenFactory = (function() {
  function TargaryenFactory() {}

  TargaryenFactory.prototype.getKing = function() {
    return new KingAerys();
  };

  TargaryenFactory.prototype.getHandOfTheKing = function() {
    return new LordConnington();
  };
  return TargaryenFactory;
})();

var CourtSession = (function() {
  function CourtSession(abstractFactory) {
    this.abstractFactory = abstractFactory;
    this.COMPLAINT_THRESHOLD = 10;
  }
  CourtSession.prototype.complaintPresented = function(complaint) {
    if (complaint.severity < this.COMPLAINT_THRESHOLD) {
      this.abstractFactory.getHandOfTheKing().makeDecision();
    } else {
      this.abstractFactory.getKing().makeDecision();
    }
  };
  return CourtSession;
})();

var session1 = new CourtSession(new TargaryenFactory());
session1.complaintPresented({ severity: 8 });
session1.complaintPresented({ severity: 12 });

var session2 = new CourtSession(new LennisterFactory());
session2.complaintPresented({ severity: 8 });
session2.complaintPresented({ severity: 12 });
