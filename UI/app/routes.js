//
// For guidance on how to create routes see:
// https://prototype-kit.service.gov.uk/docs/create-routes
//

const govukPrototypeKit = require('govuk-prototype-kit')
const router = govukPrototypeKit.requests.setupRouter()

// Add your routes here

router.post('/Check-eligible-path/is-vrn-EV', function (req, res) {
  var parking_answer = req.session.data['adequate-parking']
  if (parking_answer == "Yes") {
    res.redirect('/Check-eligible-path/is-vrn-EV')
  } else {
    res.redirect('/Check-eligible-path/Confirmation-pages/not-eligible.html')
  }
})

router.post('/Check-eligible-path/is-address-eligible', function (req, res) {
  var vrn_answer = req.session.data['user-vrn']
  if (vrn_answer != '') {
    res.redirect('/Check-eligible-path/is-address-eligible')
  } else {
    res.redirect('/Check-eligible-path/Confirmation-pages/not-eligible.html')
  }
})

router.post('/Check-eligible-path/find-eligible-address', function (req, res) {
  var postcode_answer = req.session.data['user-postcode']
  if (postcode_answer != '') {
    res.redirect('/Check-eligible-path/find-eligible-address')
  } else {
    res.redirect('/Check-eligible-path/Confirmation-pages/not-eligible.html')
  }
})

router.post('/Submission-path/check-submission-answers', function (req, res) {
  var name_answer = req.session.data['user-name']
  var email_answer = req.session.data['user-email']
  if (name_answer != '' && email_answer != '') {
    res.redirect('/Submission-path/check-submission-answers')
  } else {
    res.redirect('/Check-eligible-path/Confirmation-pages/not-eligible.html')
  }
})